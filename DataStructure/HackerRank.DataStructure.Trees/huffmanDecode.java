package DataStructure.HackerRank.DataStructure.Trees;

import java.util.HashMap;
import java.util.Map;
import java.util.PriorityQueue;
import java.util.Scanner;

public class huffmanDecode{
    // input is an array of frequencies, indexed by character code
    public static HuffmanDecodeNode buildTree(int[] charFreqs) {

        PriorityQueue<HuffmanDecodeNode> trees = new PriorityQueue<HuffmanDecodeNode>();
        // initially, we have a forest of leaves
        // one for each non-empty character
        for (int i = 0; i < charFreqs.length; i++)
            if (charFreqs[i] > 0)
                trees.offer(new HuffmanLeaf(charFreqs[i], (char)i));

        assert trees.size() > 0;

        // loop until there is only one tree left
        while (trees.size() > 1) {
            // two trees with least frequency
            HuffmanDecodeNode a = trees.poll();
            HuffmanDecodeNode b = trees.poll();

            // put into new HuffmanDecodeNode and re-insert into queue
            trees.offer(new HuffmanHuffmanDecodeNode(a, b));
        }

        return trees.poll();
    }

    public static Map<Character,String> mapA=new HashMap<Character ,String>();

    public static void printCodes(HuffmanDecodeNode tree, StringBuffer prefix) {

        assert tree != null;

        if (tree instanceof HuffmanLeaf) {
            HuffmanLeaf leaf = (HuffmanLeaf)tree;

            // print out character, frequency, and code for this leaf (which is just the prefix)
            //System.out.println(leaf.data + "\t" + leaf.frequency + "\t" + prefix);
            mapA.put(leaf.data,prefix.toString());

        } else if (tree instanceof HuffmanHuffmanDecodeNode) {
            HuffmanHuffmanDecodeNode HuffmanDecodeNode = (HuffmanHuffmanDecodeNode)tree;

            // traverse left
            prefix.append('0');
            printCodes(HuffmanDecodeNode.left, prefix);
            prefix.deleteCharAt(prefix.length()-1);

            // traverse right
            prefix.append('1');
            printCodes(HuffmanDecodeNode.right, prefix);
            prefix.deleteCharAt(prefix.length()-1);
        }
    }

    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        String test= input.next();

        // we will assume that all our characters will have
        // code less than 256, for simplicity
        int[] charFreqs = new int[256];

        // read each character and record the frequencies
        for (char c : test.toCharArray())
            charFreqs[c]++;

        // build tree
        HuffmanDecodeNode tree = buildTree(charFreqs);

        // print out results
        printCodes(tree, new StringBuffer());
        StringBuffer s = new StringBuffer();

        for(int i = 0; i < test.length(); i++) {
            char c = test.charAt(i);
            s.append(mapA.get(c));
        }

        //System.out.println(s);
        trees d = new trees();
        d.decode(s.toString(), tree);

    }
}

abstract class HuffmanDecodeNode implements Comparable<HuffmanDecodeNode> {
    public  int frequency; // the frequency of this tree
    public  char data;
    public  HuffmanDecodeNode left, right;
    public HuffmanDecodeNode(int freq) {
        frequency = freq;
    }

    // compares on the frequency
    public int compareTo(HuffmanDecodeNode tree) {
        return frequency - tree.frequency;
    }
}

class HuffmanLeaf extends HuffmanDecodeNode {


    public HuffmanLeaf(int freq, char val) {
        super(freq);
        data = val;
    }
}

class HuffmanHuffmanDecodeNode extends HuffmanDecodeNode {

    public HuffmanHuffmanDecodeNode(HuffmanDecodeNode l, HuffmanDecodeNode r) {
        super(l.frequency + r.frequency);
        left = l;
        right = r;
    }

}
