package Challanges.Euler224;

import java.util.*;

public class ProjectEuler224AlmostRightAngledTriangles2 {

    public static void CallEuler224(){
        Scanner scan = new Scanner(System.in);
        ArrayList<Integer> numbers = new ArrayList<Integer>();

        int counter=0;
        int input = scan.nextInt();
        numbers.add(input);
        while (counter!=numbers.get(0))
        {
            input = scan.nextInt();
            numbers.add(input);
            counter++;
        }
        scan.close();
        HashMap<Integer,ArrayList<Integer>> request= new HashMap<>();
        request.put(0,numbers);
        ArrayList<Integer> result=AlmostRightAngledTriangles2(request);
        for (Iterator<Integer> i = result.iterator(); i.hasNext();) {
            Integer item = i.next();
            System.out.println(item);
        }
    }

    private static ArrayList<Integer> AlmostRightAngledTriangles2( HashMap<Integer,ArrayList<Integer>> request) {
        ArrayList<Integer> numbers= request.get(0);
        ArrayList<Integer> result = new  ArrayList<Integer>();
        int counter = 0;
        int Q = numbers.get(0);

        if(Q<1 || Q>150)
            return null;

        for (int i = 1; i <= numbers.size()-1; i++) {
                counter=0;
                for (int first = 1; first <= numbers.get(i)/3; first++) {
                    if(numbers.get(i)<15 || (15* Math.pow(10,8))<numbers.get(i))
                        return null;
                    for (int second = first; second <= numbers.get(i)/2 && second>=first; second++) {
                        for (int third = second; third <= numbers.get(i) && third>=second; third++) {
                            if (IsSatisfied(first, second, third) && (first+second+third)<= numbers.get(i)) {
                                counter++;
                            }
                        }
                    }
                }
            result.add(counter);
        }
        return result;
    }

    private static boolean IsSatisfied(int first, int second, int third){
        if (    (first * first) + (second * second) == (third * third) - 1)
            return true;
        else
            return false;
    }

}
