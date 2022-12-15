using System;
class Node<datatype>{
    public datatype? value;
    public Node<datatype> next, prev;
    public Node(datatype? value){
        this.value = value;
    }
    public Node(){
        this.value = default(datatype);
    }
    ~Node(){
        this.value = default(datatype);
    }
}
class Stack<datatype>{
    private Node<datatype> _head,_tail;
    private long _size;
    public Stack(){
        this._head = new Node<datatype>();
        this._tail = new Node<datatype>();
        this._size = 0;
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
    public void push_front(datatype value){
        try{

        }catch(Exception ex){
            
        }
    }

}