using System;
using System.Collections;

namespace BST
{

    class BST_Node
    {
        public int data;
        public BST_Node left;
        public BST_Node right;
    }

    class BST
    {
        public BST_Node root;

        public void ekle(int x)
        {
            BST_Node nn = null;
            BST_Node n = root;

            while (n != null)
            {
                nn = n;

                if (x == n.data)
                    return;

                else if (x < n.data)
                    n = n.left;

                else
                    n = n.right;
            }

            BST_Node node = new BST_Node();
            node.data = x;
            node.left = node.right = null;

            if (root == null)
                root = node;

            else if (x < nn.data)
                nn.left = node;

            else
                nn.right = node;
        }

        public BST_Node arama(int x)
        {
            BST_Node n = root;

            while (n != null)
            {
                if (x == n.data)
                    return n;

                else if (x < n.data)
                    n = n.left;

                else
                    n = n.right;
            }

            return null;
        }



        public BST_Node min()
        {
            if (root == null)
            {
                Console.WriteLine("Ağaç boş...");
                return null;
            }

            if (root.left == null)
            {
                Console.WriteLine("Minimum değer: " + root.data);
                Console.WriteLine("Atası: Yok");
                Console.WriteLine("Kardeşi: Yok");
                return root;
            }

            if (root.left.left == null)
            {
                Console.WriteLine("Minimum değer: " + root.left.data);
                Console.WriteLine("Atası: Yok");
                Console.Write("Kardeşi: ");
                if (root.right == null)
                    Console.WriteLine("Yok");

                else
                    Console.WriteLine(root.right.data);

                return root.left;
            }

            BST_Node n = root;
            ArrayList ata = new ArrayList();

            while (n.left.left != null)
            {
                ata.Add(n.data);
                n = n.left;
            }

            Console.WriteLine("Minimum değer: " + n.left.data);
            Console.Write("Atası: ");

            foreach (int i in ata)
                Console.Write(i + " ");

            Console.Write("\nKardeşi: ");
            if (n.right == null)
                Console.WriteLine("Yok");
            else
                Console.WriteLine(n.right.data);

            return n.left;
        }

        public BST_Node max()
        {
            if (root == null)
            {
                Console.WriteLine("Ağaç boş...");
                return null;
            }

            if (root.right == null)
            {
                Console.WriteLine("Maksimum değer: " + root.data);
                Console.WriteLine("Atası: Yok");
                Console.WriteLine("Kardeşi: Yok");
                return root;
            }

            if (root.right.right == null)
            {
                Console.WriteLine("Maksimum değer: " + root.right.data);
                Console.WriteLine("Atası: Yok");
                Console.Write("Kardeşi: ");
                if (root.left == null)
                    Console.WriteLine("Yok");

                else
                    Console.WriteLine(root.left.data);

                return root.right;
            }

            BST_Node n = root;
            ArrayList ata = new ArrayList();

            while (n.right.right != null)
            {
                ata.Add(n.data);
                n = n.right;
            }

            Console.WriteLine("Maksimum değer: " + n.right.data);
            Console.Write("Atası: ");

            foreach (int i in ata)
                Console.Write(i + " ");

            Console.Write("\nKardeşi: ");
            if (n.left == null)
                Console.WriteLine("Yok");
            else
                Console.WriteLine(n.left.data);

            return n.right;
        }

        public void silme(int x)
        {
            if (root == null)
            {
                Console.WriteLine("Hata...\nAğaç boş");
                return;
            }

            BST_Node n = root;
            BST_Node nn = null;

            while (n.left != null || n.right != null)
            {
                nn = n;

                if (x < n.data)
                    n = n.left;

                else if (x > n.data)
                    n = n.right;

                else if (x == n.data)
                    break;
            }

            if (n.data != x)
            {
                Console.WriteLine(x + " değeri bulunamadı...");
                return;
            }

            if (n.left == null && n.right == null)
            {
                if (x == root.data)
                {
                    root = null;
                    Console.WriteLine(x + " değeri silindi");
                    return;
                }

                if (nn.left == n)
                    nn.left = null;

                else if (nn.right == n)
                    nn.right = null;

                return;
            }

            if (n.left == null && n.right != null)
            {
                if (x == root.data)
                {
                    BST_Node rmin = root.right;

                    if (rmin.right == null)
                    {
                        n.data = rmin.data;
                        n.right = rmin.right;
                        return;
                    }

                    while (rmin.left.left != null)
                        rmin = rmin.left;

                    n.data = rmin.left.data;
                    rmin.left = null;
                    return;
                }

                n.data = n.right.data;
                n.right = null;

                return;
            }

            if (n.left != null && n.right == null)
            {
                if (x == root.data)
                {
                    BST_Node lmax = root.left;

                    if (lmax.left == null)
                    {
                        n.data = lmax.data;
                        n.left = lmax.left;
                        return;
                    }

                    while (lmax.right.right != null)
                        lmax = lmax.right;

                    n.data = lmax.right.data;
                    lmax.right = null;
                    return;
                }

                n.data = n.left.data;
                n.left = null;

                return;
            }

            if (n.left != null && n.right != null)
            {
                BST_Node lmax = n.left;

                if (lmax.right == null)
                {
                    n.data = lmax.data;
                    n.left = lmax.left;
                    return;
                }


                while (lmax.right.right != null)
                    lmax = lmax.right;

                n.data = lmax.right.data;
                lmax.right = null;
                return;
            }
        }

        //https://www.geeksforgeeks.org/level-order-tree-traversal/ kaynağından yardım alınmıştır.
        public void levelOrder()
        {
            if (root == null)
            {
                Console.WriteLine("Ağaç boş...");
                return;
            }

            int h = yukseklik(root);
            int i;
            for (i = 1; i <= h; i++)
                levelBul(root, i);

            Console.WriteLine();
        }

        public int yukseklik(BST_Node root)
        {
            if (root == null)
                return 0;

            else
            {
                int lheight = yukseklik(root.left);
                int rheight = yukseklik(root.right);

                if (lheight > rheight)
                    return lheight + 1;

                return rheight + 1;
            }
        }

        public void levelBul(BST_Node root, int level)
        {
            if (root == null)
                return;

            if (level == 1)
                Console.Write(root.data + " ");

            else if (level > 1)
            {
                levelBul(root.left, level - 1);
                levelBul(root.right, level - 1);
            }
        }
    }

    class BST_Main
    {
        static void Main(string[] args)
        {
            BST bst = new BST();

            //Min-Max Değerler, Ataları ve Kardeşleri, Level Order Yazma
            /*
            bst.ekle(20);
            bst.levelOrder();
            bst.min();
            bst.max();
            Console.WriteLine();

            bst.ekle(10);
            bst.levelOrder();
            bst.min();
            bst.max();
            Console.WriteLine();

            bst.ekle(30);
            bst.levelOrder();
            bst.min();
            bst.max();
            Console.WriteLine();

            bst.ekle(5);
            bst.ekle(2);
            bst.ekle(3);
            bst.ekle(1);
            bst.ekle(35);
            bst.ekle(37);
            bst.ekle(36);
            bst.ekle(38);
            bst.levelOrder();
            bst.min();
            bst.max();
            */

            //Sadece Kök Düğümü Olan Bir Ağaçtan Olmayan Bir Değer ve Kökü Silme İşlemi
            /*
            bst.ekle(17);
            bst.levelOrder();
            Console.WriteLine();
            
            bst.silme(8);
            bst.silme(17);
            bst.levelOrder();
            Console.WriteLine();
            */

            //Tek Çocuğu Solda Bulunan Kökün Silinmesi
            /*
            bst.ekle(17);
            bst.ekle(8);
            bst.levelOrder();
            Console.WriteLine();

            bst.silme(17);
            bst.levelOrder();
            */

            //Tek Çocuğu Sağda Bulunan Kökün Silinmesi
            /*
            bst.ekle(17);
            bst.ekle(25);
            bst.levelOrder();
            Console.WriteLine();

            bst.silme(17);
            bst.levelOrder();
            */


            //İki Çocuğu Bulnan Kökün Silinmesi
            /*
            bst.ekle(17);
            bst.ekle(8);
            bst.ekle(25);
            bst.levelOrder();
            Console.WriteLine();

            bst.silme(17);
            bst.levelOrder();*/


            bst.ekle(17);
            bst.ekle(8);
            bst.ekle(25);
            bst.ekle(5);
            bst.ekle(2);
            bst.ekle(14);
            bst.ekle(12);
            bst.ekle(15);
            bst.ekle(20);
            bst.ekle(30);
            bst.ekle(23);
            bst.ekle(1);
            bst.levelOrder();
            Console.WriteLine();

            //Yaprak Düğümün Silinmesi
            bst.silme(23);
            bst.levelOrder();
            Console.WriteLine();

            //Tek Çocuğu Olan Düğümün Silinmesi
            bst.silme(2);
            bst.levelOrder();
            Console.WriteLine();

            //İki Çocuğu Olan Düğümün Silinmesi
            bst.silme(8);
            bst.levelOrder();
            Console.WriteLine();
        }
    }
}
