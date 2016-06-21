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
            

            gameObject.Add(new Player(100, 5, 5, 2, 2, 5));
            gameObject.Add(new SteelWall(100, 1, 10, 10, 1));

            controleObject = GetControleObject();

            
                ControleObject.GetInretsect += this.GetIntersect;
            
                
        }
        public Player ControleObject
        {
            get { return controleObject; }
        }

        public void UpdateAll() {
            foreach (DrawingObject item in gameObject) {
                item.Update();
            }
        }

        public void GetIntersect(object sender, EventArgs e) {
           
            foreach (DrawingObject item in gameObject)
            {
                if (((DrawingObject)sender).DrawRect.IntersectsWith(item.DrawRect) && sender != item)
                {
                    //((DrawingObject)sender).xStartPos = 1;
                    //((DrawingObject)sender).yStartPos = 1;
                    ((DynamicObject)sender).isCanMove = false;
                }
                else ((DynamicObject)sender).isCanMove = true;

            }
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
            //return gameObject.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public static event EventHandler Interact;
    }

  
}
