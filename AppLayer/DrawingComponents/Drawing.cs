using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;

namespace AppLayer.DrawingComponents
{
    // NOTE: This class at least one  problem that is hurting coupling and cohesion

    public class Drawing
    {
        private static readonly DataContractJsonSerializer JsonSerializer =
                new DataContractJsonSerializer(typeof(List<Element>), new [] { typeof(Element), typeof(Tree), typeof(TreeWithAllState), typeof(TreeExtrinsicState), typeof(LabeledBox), typeof(Line) });
        private static readonly DataContractJsonSerializer JsonSerializerBackground =
                new DataContractJsonSerializer(typeof(List<Background>), new[] { typeof(Background) });

        private readonly List<Element> _elements = new List<Element>();
        private readonly List<Background> _backgrounds = new List<Background>();
        private readonly object _myLock = new object();

        public bool IsDirty { get; set; } = true;

        public List<Element> GetCloneOfElements()
        {
            var cloneList = new List<Element>();
            lock (_myLock)
            {
                cloneList.AddRange(_elements.Select(element => element.Clone()));
            }

            return cloneList;           
        }

        public void Clear()
        {
            lock (_myLock)
            {
                _elements.Clear();
                IsDirty = true;
            }
        }

        public void LoadFromStream(Stream stream)
        { 
            // The file has objects for the elements and the backgrounds seperated by an @ symbol
            StreamReader reader = new StreamReader(stream);
            string doc = reader.ReadToEnd();
            string[] splitDoc = doc.Split('@');

            // split the files, set back to bytes and deserialize them
            // Requirement 6
            byte[] splitBytesElements = Encoding.UTF8.GetBytes(splitDoc[0]);
            MemoryStream elementsStream = new MemoryStream(splitBytesElements);
            var loadedElements = JsonSerializer.ReadObject(elementsStream) as List<Element>;

            byte[] splitBytesBackgrounds = Encoding.UTF8.GetBytes(splitDoc[1]);
            MemoryStream backgroundsStream = new MemoryStream(splitBytesBackgrounds);
            var loadedBackgrounds = JsonSerializerBackground.ReadObject(backgroundsStream) as List<Background>;


            if (loadedElements == null || loadedElements.Count == 0) return;

            lock (_myLock)
            {
                // Since only the extrinsic state is saved, recreate the full tree objects
                foreach (var element in loadedElements)
                {
                    var tmpTree = element as TreeWithAllState;
                    if (tmpTree != null)
                    {
                        Tree fullTree = TreeFactory.Instance.GetTree(tmpTree.ExtrinsicState);
                        _elements.Add(fullTree);
                    }
                    else
                    {
                        _elements.Add(element);
                    }
                }
                if (loadedElements != null && loadedElements.Count != 0)
                { 
                    foreach (var background in loadedBackgrounds)
                    {
                        background.convertBytesToMap();
                        _backgrounds.Add(background);
                    }
                }
                IsDirty = true;
            }
        }

        public void SaveToStream(Stream stream)
        {
            lock (_myLock)
            {
                JsonSerializer.WriteObject(stream, _elements);
                byte[] escape = { Convert.ToByte('@') };
                stream.Write(escape, 0, 1);
                foreach (var background in _backgrounds)
                {
                    background.convertMapToBytes();
                }
                JsonSerializerBackground.WriteObject(stream, _backgrounds);
            }
        }

        public void Add(Element element)
        {
            if (element == null) return;

            lock (_myLock)
            {
                _elements.Add(element);
                IsDirty = true;
            }
        }

        public List<Element> DeleteAllSelected()
        {
            List<Element> elementsToDelete;
            lock (_myLock)
            {
                elementsToDelete = _elements.FindAll(t => t.IsSelected);
                _elements.RemoveAll(t => t.IsSelected);
                IsDirty = true;
            }

            return elementsToDelete;
        }

        public void DeleteElement(Element element)
        {
            lock (_myLock)
            {
                _elements.Remove(element);
                IsDirty = true;
            }
        }

        public Element FindElementAtPosition(Point point)
        {
            Element result;
            lock (_myLock)
            {
                result = _elements.FindLast(t => t.ContainsPoint(point));
            }
            return result;
        }

        public List<Element> DeselectAll()
        {
            var selectedElements = new List<Element>();
            lock (_myLock)
            {
                foreach (var t in _elements.Where(t => t.IsSelected))
                {
                    selectedElements.Add(t);
                    t.IsSelected = false;
                }
                IsDirty = true;
            }
            return selectedElements;
        }

        public bool Draw(Graphics graphics, bool redrawEvenIfNotDirty = false)
        {
            lock (_myLock)
            {
                if (!IsDirty && !redrawEvenIfNotDirty) return false;

                graphics.Clear(Color.White); // White as default background
                if (_backgrounds.Count > 0 ) {
                    graphics.DrawImage(_backgrounds.Last().map, new Point(0, 0));
                }
                foreach (var t in _elements)
                    t.Draw(graphics);
                IsDirty = false;
            }
            return true;
        }

        public bool SetBackground(Background background)
        {
            if (background == null) return false;
            lock (_myLock)
            {
                _backgrounds.Add(background);
                IsDirty= true;
            }
            return true;
        }
        public bool RemoveLastBackground()
        {
            if (_backgrounds == null) return false;
            lock (_myLock)
            {
                _backgrounds.RemoveAt(_backgrounds.Count - 1);
                IsDirty = true;
            }
            return true;
        }
        public Element GetSelected()
        {
            foreach (var element in _elements)
            {
                if (element.IsSelected == true) return element;
            }
            return null;
        }
        public bool MoveSelected(Element selected, Point oldLocation, Point newLocation)
        {
            Element toChange = FindElementAtPosition(oldLocation);
            
            return true;
        }

    }
}
