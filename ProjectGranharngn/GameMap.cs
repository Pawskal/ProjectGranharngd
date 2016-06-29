using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ProjectGranharngn
{
    public class GameMap : IEnumerable<IDrawable>
    {
        public List<IDrawable> gameObject;

        private Player controleObject;
        
        public GameMap() {

            gameObject = new List<IDrawable>();
            

            gameObject.Add(new Player(1000000, 5, 5, 2, 2, 200, 200));
            gameObject.Add(new SteelWall(100, 1, 10, 10, 1));

            controleObject = GetControleObject();

            
            ControleObject.GetInretsect += this.GetIntersect;
            
                
        }
        public Player ControleObject
        {
            get { return controleObject; }
        }

        

        public bool GetIntersect(DynamicObject sender, IntersectEventArgs e) {

          foreach (DrawingObject item in gameObject)
            {
                if (e.rect.IntersectsWith(item.DrawRect) && sender.DrawRect != item.DrawRect)
                {
                    e.IntersectedObj = item;
                    return false; // не может переместится
                }
            }
        return true; //перемешение;
        }

        private Player GetControleObject(){
            string temp = new Player().ToString();
            foreach (DrawingObject item in gameObject)
            {
                if (temp == item.ToString())
                {
                    return (Player)item;
                }
            }
            return null;
        }

        public IEnumerator<IDrawable> GetEnumerator() {
            foreach (var item in gameObject)
            {
                yield return item;
            }
         }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

  
}
