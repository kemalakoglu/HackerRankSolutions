package DataStructure.HackerRank.DataStructure.Trees;
import java.io.*;
        import java.util.*;
        import java.text.*;
        import java.math.*;
        import java.util.regex.*;
        import static java.lang.Math.pow;

class KittyNode{
    ArrayList<KittyNode> next = new ArrayList<KittyNode>(); //next is an arrayList which stores the data of all children KittyNodes
    int data;
    int lvl;//level of the KittyNode, root has lvl 0 and it increases at every lvl by 1
    KittyNode prev; // prev stored the data of parent KittyNode
}

public class kittysCalculationsOnATree extends KittyNode{

    public static KittyNode findKittyNode(int n, KittyNode root){
        if(root == null)
            return root;
        if(root.data == n)
            return root;
        Iterator itr = root.next.iterator();
        KittyNode a = null;
        while(itr.hasNext() && a == null){
            a = findKittyNode(n, (KittyNode)itr.next());
        }
        if(a != null)
            return a;
        return null;
    }
    public static void attachKittyNode(KittyNode a, KittyNode b){
        a.next.add(b);
        b.prev = a;
        b.lvl = a.lvl + 1;
    }

    //kittyFxn is our core function here
    public static int kittyFxn(ArrayList<Integer> array, KittyNode root){
        int sum = 0;
        int arr[] = new int[array.size()];
        //convert arrayList to array
        for(int k=0; k<array.size(); k++){
            arr[k] = array.get(k);
        }
        for(int i=0; i<arr.length; i++){
            for(int j=i+1; j<arr.length; j++){
                sum += arr[i]*arr[j]*distKittyNode(findKittyNode(arr[i],root),findKittyNode(arr[j],root));
            }
        }
        return sum%((int)pow(10,9)+7);
    }

    //returns the distance between KittyNodes a and b
    public static int distKittyNode(KittyNode a, KittyNode b){
        KittyNode c = commAns(a,b);
        return a.lvl + b.lvl - 2*c.lvl;//since distance between 2 KittyNodes is the sum of the distances between lowest common KittyNode and the 2 KittyNodes
    }

    //this returns the most recent common KittyNode between KittyNodes a and b
    public static KittyNode commAns(KittyNode a, KittyNode b){
        KittyNode trava,travb;
        trava = a;
        travb = b;
        if(trava == null)
            return travb;
        else if(travb == null)
            return trava;
        while(trava.prev != null || travb.prev != null){
            if(trava.lvl == travb.lvl){
                if(trava.prev == travb.prev)
                    return trava.prev;
                trava = trava.prev;
                travb = travb.prev;
            }
            else if(trava.lvl > travb.lvl){
                if(trava.prev == travb)
                    return travb;
                trava = trava.prev;
            }else if(trava.lvl < travb.lvl){
                if(trava == travb.prev)
                    return trava;
                travb = travb.prev;
            }
        }
        if(trava != null)
            return trava;
        else
            return travb;
    }

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = sc.nextInt();
        int q = sc.nextInt();
        KittyNode root = new KittyNode();
        root.data = 1;
        root.lvl = 0;
        root.prev = null;
        KittyNode a = root;
        KittyNode c;
        for(int i=0; i<n-1; i++){
            int rute = sc.nextInt();
            int brn = sc.nextInt();
            KittyNode b = new KittyNode();
            b.data = brn;
            c = findKittyNode(rute,root);
            attachKittyNode(c,b);
        }
        ArrayList<Integer> arr = new ArrayList<Integer>();
        for(int j=0; j<q; j++){
            arr.clear();
            int k = sc.nextInt();
            for(int l=0; l<k; l++)
                arr.add(sc.nextInt());
            System.out.println(kittyFxn(arr,root));
        }
    }
}
