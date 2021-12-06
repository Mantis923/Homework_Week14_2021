using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/// File Name: Lab - Homework_Week14_2021
/// Student: Samuel Peppetta
/// Miracosta college fall 2021
/// Professor Mark Akola


namespace Homework_Week14_2021
{
    /// Created is the Person class.
    ///Add at least 10 people to a list and create the following statements.
    ///Finding the people eligible for the kids menu.Those who are 12 or younger.
    ///A query is written which list out the people who are taller than the average height 
    ///of all the people.This required you to find the average height of the people.
    ///The average  used to loop over everyone and calculated.
    public partial class Person : System.Web.UI.Page // we are working on one portion of the larger class
    {
        protected void Page_Load(object sender, EventArgs e)  //Page_Load is the initialization of the GUI (first thing to run like Main)
        {
            List<person> myList = new List<person>(); //using List (as a dynamic array)
            person p1 = new person("Mark", 12, 6.2);
            person p2 = new person("John", 15, 5.0);
            person p3= new person("Rick",17, 6.0) ;
            person p4 = new person("Bob", 10, 5.5);

            myList.Add(p1);// or myList.Add(new person("Mark", 12, 6.2)); this is doing  everything in a shorter way: creating Person object
                           //and MyList all in one.
                           //Warning!!!! To edit the object in the in "myList" we must access the object from "myList" First!!! We CANNOT MAKE CHANGES TO P1 TO CHANGE THE LIST.
            myList.Add(p2);
            myList.Add(p3);
            myList.Add(p4);// after this line if we make changes to p1-p4 it will not update the list, the list will still REMAIN THE SAME!!!
                          //Lastly the copy needlessly takes up memory (2X the memory). Which is kind of wasteful right???

            //PView.DataSource = from a in myList select a;
            //PView.DataSource = from a in myList where a.Age <= 12 select a; 
            int personCount = (from pa in myList                           
                             //where pa.Age > 18
                               orderby pa.Name , pa.Height , pa.Age  //orderby sorts the list by their names ,height and age
                               select pa).Count();                   //gets the number of persons saved in the list sort of like the number of indexes
            double average = 0;
            double sum = 0; 
            foreach(var pp in myList)         //selects each person alphabetically which was sorted as noted on line 32
            {
                sum += pp.Height; 
            }
            average = sum / personCount;
            PView.DataSource = from a in myList where a.Height >= average select a; // this could be for age as well make sure foreach is set up for age too!
            PView.DataBind();                                                      //the end of the GUI PView.DataBind() is the function that updates the display


        }
        public class person
        {
            private string name;
          private int age;
          private double height; 

            public person(string name , int age, double height)
            {
                this.Age = age;
                this.Name = name;
                this.Height = height; 
            }

            public string Name { get => name; set => name = value; }
            public int Age { get => age; set => age = value; }
            public double Height { get => height; set => height = value; }
        }
    }
}