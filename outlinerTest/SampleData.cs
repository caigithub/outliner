using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using outliner;

namespace outlinerTest
{
    public class SampleData
    {
        public static Content contentTree()
        {
            // root
            //      aa
            //          aa_child_1
            //          aa_child_2
            //          ....
            //          aa_child_9
            //      bb
            //          bb_child_1
            //          bb_child_2
            //          ....
            //          bb_child_9

            Content root = new Content();
            root.Name = "root";

            root.addChild( contentNode("aa", 9));
            root.addChild( contentNode("bb", 9));

            return root;
        }

        public static Content contentNode(string name, int child_number)
        {
            Content first = new Content();
            first.Name = name;

            for (int i = 0; i < child_number; i++)
            {
                Content new_child = new Content();
                new_child.Name = "child_" + i.ToString();
                first.addChild(new_child);
            }

            return first;
        }

        public static Content contentNode(string name)
        {
            Content first = new Content();
            first.Name = name;
            return first;
        }

        public static Content contentNode() {
            Content first = new Content();
            first.Name = "sample node";
            return first;
        }
    }
}
