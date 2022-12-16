using System;
using System.Collections.Generic;
namespace Practica3{
    
}
public class Node<datatype>{
    public datatype value;
    public Node<datatype> next, prev;
    public Node(datatype value){
        this.value = value;
    }
    public Node(){
        this.value = default(datatype);
    }
    ~Node(){
        Console.WriteLine("Deleting node...");
        this.value = default(datatype);
    }
}
public class LinkedList<datatype>{
    protected Node<datatype> _head,_tail;
    protected long _size;
    public LinkedList(){
        this._head = new Node<datatype>();
        this._tail = new Node<datatype>();
        this._size = 0;
    }
    
    public LinkedList(List<datatype> items){
        foreach(var i in items){
            this.push_back(i);
        }
    }
    public bool isEmpty(){
        return (this._size <= 0) ? true : false;
    }
    public datatype Front(){
        return this._head.value;
    }
    public datatype Back(){
        return this._tail.value;
    }
    public void push_back(datatype value){
        try{
            Node<datatype> newNode = new Node<datatype>(value);
            if(isEmpty()){
                _head = newNode;
                _tail = newNode;
                _head.next = _tail;
                _tail.prev = _head;
            }
            else{
                _tail.next = newNode;
                newNode.prev = _tail;
                _tail = newNode;
            }
            _size++;
        }catch(Exception ex){
            Console.WriteLine("Error adding the node...\n" + ex.ToString());
        }
    }
    public void push_front(datatype value){
        try{
            Node<datatype> newNode = new Node<datatype>(value);
            if(isEmpty()){
                _head = newNode;
                _head.next = _tail;
                _tail.prev = _head;
            }else{
                newNode.next = _head;
                _head = newNode;
            }
            _size++;
        }catch(Exception ex){
            Console.WriteLine("Error trying to add the node...\n" + ex.ToString());
        }
    }
    public void pop_front(){
        try{
            if(isEmpty()) return;
            else{
                _head = _head.next;
                _size--;
            }
        }catch(Exception ex){
            Console.WriteLine("Error trying to delete the element...\n" + ex.ToString());
        }
    }
    public void pop_back(){
        try{
            if(isEmpty()) return;
            else{
                _tail = _tail.prev;
                _size--;
            }
        }catch(Exception ex){
            Console.WriteLine("Error trying to delete...\n" + ex.ToString());
            return;
        }
    }
    public long size(){
        return this._size;
    }
    public void printFromFront(){
        var tmp = this;
        while(!tmp.isEmpty()){
            Console.WriteLine(tmp.Front().ToString());
            tmp.pop_front();
        }
    }
    public void printFromBack(){
        var tmp = this;
        while(!tmp.isEmpty()){
            Console.WriteLine(tmp.Back().ToString());
            tmp.pop_back();
        }
    }
    ~LinkedList(){
        try{
            Console.WriteLine("Clearing elements...\n");
            _head = _tail = null;
            _size = 0;
            Console.WriteLine("Complete...\n");
        }catch(Exception ex){
            Console.WriteLine("Error trying to clean the elements...\n" + ex.ToString());
        }
    }
}
public class CircularQueue<datatype> : LinkedList<datatype>{
    public CircularQueue(){
        this._head = new Node<datatype>();
        this._tail = new Node<datatype>();
    }
    public CircularQueue(List<datatype> items){
        foreach(var i in items) this.push(i);
    }
    public void push(datatype value){
        push_back(value);
    }
    public void pop(){
        pop_front();
    }
    public void print(){
        while(!isEmpty()){
            Console.WriteLine(this.Front());
            pop();
        }
    }
}
public class MainClass{
    public static CircularQueue<int> globalCircularQueue;
    public static CircularQueue<int> init(){
        CircularQueue<int> tmp = new CircularQueue<int>(new List<int>{1,2,3,4,5,6,7,8,9,10});
        return tmp;
    }
    static void Main(){
        CircularQueue<int> localCircularQueue = init();
        Console.WriteLine("Local:");
        globalCircularQueue = init();
        localCircularQueue.print();
        Console.WriteLine("Global:");
        globalCircularQueue.print();

    }
}