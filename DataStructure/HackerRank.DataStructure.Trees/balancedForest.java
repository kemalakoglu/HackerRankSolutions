package DataStructure.HackerRank.DataStructure.Trees;
import java.io.*;
import java.util.*;


public class balancedForest {

    static int time;
    static long minAddition;
    // Complete the balancedForest function below.
    static int balancedForest(int[] c, int[][] edges) {

        //ArrayList<GraphNode> graphNodes=  new ArrayList<GraphNode>();

        GraphNode[] graphNodes= {};

        for(int index = 0; index < c.length; index++) {
            GraphNode graph = new GraphNode(c[index]);
            graphNodes[index]=graph;
        }

        if (graphNodes.length < 3) {
            return -1;
        }

        int graphRootNodeIndex = findGraphRootNodeIndexWithMinHeight(graphNodes);
        TreeNode treeRoot = buildTree(graphNodes, graphRootNodeIndex);

        Map<Long, NavigableSet<Integer>> valueSumToEnterTimes = new HashMap<>();
        Map<Long, NavigableSet<Integer>> valueSumToLeaveTimes = new HashMap<>();
        computeSubtreeValueSums(treeRoot, valueSumToEnterTimes, valueSumToLeaveTimes);

        minAddition = Long.MAX_VALUE;
        cut(treeRoot.valueSum, valueSumToEnterTimes, valueSumToLeaveTimes, treeRoot);

        if (minAddition == Long.MAX_VALUE)
            return -1;
        else
            return (int) minAddition;


    }

    private static final Scanner scanner = new Scanner(System.in);

    public static void main(String[] args) throws IOException {
        //BufferedWriter bufferedWriter = new BufferedWriter(new FileWriter(System.getenv("OUTPUT_PATH")));

        int q = scanner.nextInt();
        scanner.skip("(\r\n|[\n\r\u2028\u2029\u0085])?");

        if (args.length != 0)
        {
            for (int qItr = 0; qItr < q; qItr++) {
                int n = scanner.nextInt();
                scanner.skip("(\r\n|[\n\r\u2028\u2029\u0085])?");

                int[] c = new int[n];

                String[] cItems = scanner.nextLine().split(" ");
                scanner.skip("(\r\n|[\n\r\u2028\u2029\u0085])?");

                for (int i = 0; i < n; i++) {
                    int cItem = Integer.parseInt(cItems[i]);
                    c[i] = cItem;
                }

                int[][] edges = new int[n - 1][2];

                for (int i = 0; i < n - 1; i++) {
                    String[] edgesRowItems = scanner.nextLine().split(" ");
                    scanner.skip("(\r\n|[\n\r\u2028\u2029\u0085])?");

                    for (int j = 0; j < 2; j++) {
                        int edgesItem = Integer.parseInt(edgesRowItems[j]);
                        edges[i][j] = edgesItem;
                    }
                }

                int result = balancedForest(c, edges);

                //bufferedWriter.write(String.valueOf(result));
                //bufferedWriter.newLine();
            }
        }


        //bufferedWriter.close();

        scanner.close();
    }

    static boolean otherContains(Map<Long, NavigableSet<Integer>> valueSumToEnterTimes,
                                 Map<Long, NavigableSet<Integer>> valueSumToLeaveTimes, TreeNode treeNode, long targetValueSum) {
        if (valueSumToLeaveTimes.containsKey(targetValueSum)
                && valueSumToLeaveTimes.get(targetValueSum).lower(treeNode.enterTime) != null) {
            return true;
        }
        if (valueSumToEnterTimes.containsKey(targetValueSum)
                && valueSumToEnterTimes.get(targetValueSum).higher(treeNode.leaveTime) != null) {
            return true;
        }

        for (TreeNode p = treeNode.parent; p != null; p = p.parent) {
            if (p.valueSum - treeNode.valueSum == targetValueSum) {
                return true;
            }
        }

        return false;
    }

    static void cut(long originalTotal, Map<Long, NavigableSet<Integer>> valueSumToEnterTimes,
                    Map<Long, NavigableSet<Integer>> valueSumToLeaveTimes, TreeNode treeNode) {
        long cutValueSum = treeNode.valueSum;
        long remainTotal = originalTotal - cutValueSum;
        if (cutValueSum <= remainTotal) {
            if (cutValueSum == remainTotal) {
                minAddition = Math.min(minAddition, cutValueSum);
            } else {
                if (remainTotal % 2 == 0) {
                    long halfRemainTotal = remainTotal / 2;
                    if (halfRemainTotal >= cutValueSum
                            && otherContains(valueSumToEnterTimes, valueSumToLeaveTimes, treeNode, halfRemainTotal)) {
                        minAddition = Math.min(minAddition, halfRemainTotal - cutValueSum);
                    }
                }

                long otherValueSum = remainTotal - cutValueSum;
                if (cutValueSum >= otherValueSum && (otherContains(valueSumToEnterTimes, valueSumToLeaveTimes, treeNode,
                        cutValueSum)
                        || otherContains(valueSumToEnterTimes, valueSumToLeaveTimes, treeNode, otherValueSum))) {
                    minAddition = Math.min(minAddition, cutValueSum - otherValueSum);
                }
            }
        }

        for (TreeNode child : treeNode.children) {
            cut(originalTotal, valueSumToEnterTimes, valueSumToLeaveTimes, child);
        }
    }

    static void computeSubtreeValueSums(TreeNode treeNode, Map<Long, NavigableSet<Integer>> valueSumToEnterTimes,
                                        Map<Long, NavigableSet<Integer>> valueSumToLeaveTimes) {
        treeNode.valueSum = treeNode.value;
        for (TreeNode child : treeNode.children) {
            computeSubtreeValueSums(child, valueSumToEnterTimes, valueSumToLeaveTimes);
            treeNode.valueSum += child.valueSum;
        }

        addToValueSumToTimes(valueSumToEnterTimes, treeNode.valueSum, treeNode.enterTime);
        addToValueSumToTimes(valueSumToLeaveTimes, treeNode.valueSum, treeNode.leaveTime);
    }

    static void addToValueSumToTimes(Map<Long, NavigableSet<Integer>> valueSumToTimes, long valueSum, int time) {
        if (!valueSumToTimes.containsKey(valueSum)) {
            valueSumToTimes.put(valueSum, new TreeSet<>());
        }

        valueSumToTimes.get(valueSum).add(time);
    }

    static TreeNode buildTree(GraphNode[] graphNodes, int graphRootNodeIndex) {
        time = 0;
        return buildTreeNode(graphNodes, graphRootNodeIndex, new boolean[graphNodes.length], null);
    }

    static TreeNode buildTreeNode(GraphNode[] graphNodes, int graphNodeIndex, boolean[] visited, TreeNode parent) {
        visited[graphNodeIndex] = true;

        TreeNode treeNode = new TreeNode(graphNodes[graphNodeIndex].value, parent);

        time++;
        treeNode.enterTime = time;

        for (int adjacent : graphNodes[graphNodeIndex].adjacents) {
            if (!visited[adjacent]) {
                treeNode.children.add(buildTreeNode(graphNodes, adjacent, visited, treeNode));
            }
        }

        time++;
        treeNode.leaveTime = time;

        return treeNode;
    }

    static int findGraphRootNodeIndexWithMinHeight(GraphNode[] graphNodes) {
        boolean[] visited = new boolean[graphNodes.length];
        Queue<Integer> queue = new LinkedList<>();
        for (int i = 0; i < graphNodes.length; i++) {
            if (graphNodes[i].adjacents.size() == 1) {
                visited[i] = true;
                queue.offer(i);
            }
        }

        int rootGraphIndex = -1;
        while (!queue.isEmpty()) {
            int head = queue.poll();
            rootGraphIndex = head;

            for (int adjacent : graphNodes[head].adjacents) {
                if (!visited[adjacent]) {
                    visited[adjacent] = true;
                    queue.offer(adjacent);
                }
            }
        }
        return rootGraphIndex;
    }
}

 class GraphNode {
    int value;
    List<Integer> adjacents = new ArrayList<>();

    GraphNode(int value) {
        this.value = value;
    }
}

class TreeNode {
    int value;
    TreeNode parent;
    List<TreeNode> children = new ArrayList<>();
    int enterTime;
    int leaveTime;
    long valueSum;

    TreeNode(int value, TreeNode parent) {
        this.value = value;
        this.parent = parent;
    }
}

