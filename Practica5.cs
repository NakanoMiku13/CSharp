using System;
using System.Collections.Generic;
public class Pair<datatype1,datatype2>{
    public datatype1 first;
    public datatype2 second;
    public Pair(){
        this.first = default(datatype1);
        this.second = default(datatype2);
    }
    public Pair(datatype1 first, datatype2 second){
        this.first = first;
        this.second = second;
    }
}
public class figure<datatype>{
    protected datatype _x_position,_y_position;
    protected double _area;
    public figure(datatype x_position = default(datatype),datatype y_position = default(datatype), double area = 0){
        this._x_position = x_position;
        this._y_position = y_position;
        this._area = area;
    }
    public void setXPosition(datatype x_position){
        this._x_position = x_position;
    }
    public void setYPosition(datatype y_position){
        this._y_position = y_position;
    }
    public void setPosition(datatype x_position,datatype y_position){
        this._x_position = x_position;
        this._y_position = y_position;
    }
    public void setArea(double area){
        this._area = area;
    }
    public double getArea(){
        return this._area;
    }
    public Pair<datatype,datatype>getComposedPosition(){
        return new Pair<datatype,datatype>(this._x_position, this._y_position);
    }
    public datatype getXPosition(){
        return this._x_position;
    }
    public datatype getYPosition(){
        return this._y_position;
    }
}
public class rectangle<datatype> : figure<datatype>{
    private datatype _base, _hight;
    public rectangle(datatype base1 = default(datatype), datatype hight = default(datatype) ,double area = 0, datatype x_position = default(datatype), datatype y_position = default(datatype)) : base(x_position, y_position,area){
        this._base = base1;
        this._hight = hight;
        calculateArea();
    }
    public void calculateArea(){
        try{
            this._area = (Convert.ToDouble(_hight) * Convert.ToDouble(_base));
        }catch(Exception exception){
            Console.WriteLine("Error trying to calculate area... \n" + exception.ToString());
        }finally{
            this._area = 0;
        }
    }
    public datatype getBase(){
        return this._base;
    }
    public datatype getHigh(){
        return this._hight;
    }
    public void setBase(datatype base1){
        this._base = base1;
    }
    public void setHight(datatype hight){
        this._hight = hight;
    }
}
public class square<datatype> : figure<datatype>{
    private datatype _side;
    public square(datatype side = default(datatype), double area = 0, datatype x_position = default(datatype), datatype y_position = default(datatype)) : base(x_position,y_position,area){
        this._side = side;
    }
    public void calculateArea(){
        try{
            this._area = Convert.ToDouble(this._side) * Convert.ToDouble(this._side);
        }catch(Exception ex){
            Console.WriteLine("Error trying to calculate the area...\n" + ex.ToString());
        }finally{
            this._area = 0;
        }
    }
    public void setSide(datatype side){
        this._side = side;
    }
    public datatype getSide(){
        return this._side;
    }
}
public class triangle<datatype> : figure<datatype>{
    private datatype _base, _hight, _leftSide, _rightSide;
    public triangle(datatype base1 = default(datatype), datatype hight = default(datatype), datatype leftSide = default(datatype), datatype rightSide = default(datatype), datatype x_position = default(datatype), datatype y_position = default(datatype), double area = 0) : base(x_position,y_position,area){
        this._base = base1;
        this._hight = hight;
        this._leftSide = leftSide;
        this._rightSide = rightSide;
    }
    public datatype Base{
        get { return this._base; }
        set { this._base = value; }
    }
    public datatype LeftSide{
        get { return this._leftSide; }
        set { this._leftSide = value; }
    }
    public datatype RightSide{
        get { return this._rightSide; }
        set { this._rightSide = value; }
    }
    public datatype Hight{
        get { return this._hight; }
        set { this._hight = value; }
    }
    public void calculateArea(){
        try{
            this._area = ( Convert.ToDouble(this._base) * Convert.ToDouble(this._hight) ) / 2;
        }catch(Exception ex){
            Console.WriteLine("Error calculating area...\n"+ex.ToString());
        }finally{
            this._area = 0;
        }
    }
}
public class circle<datatype> : figure<datatype>{
    private datatype _radius;
    public circle(datatype radius = default(datatype), double area = 0, datatype x_position = default(datatype), datatype y_position = default(datatype)) : base(x_position,y_position,area){
        this._radius = radius;
    }
    public void setRadius(datatype radius){
        this._radius = radius;
    }
    public datatype getRadius(){
        return this._radius;
    }
    public void calculateArea(){
        try{
            this._area = (3.141516) * (Convert.ToDouble(this._radius) * Convert.ToDouble(this._radius));
        }catch(Exception ex){
            Console.WriteLine("Error trying to calculate area...\n"+ex.ToString());
        }finally{
            this._area = 0;
        }
    }
}
public class scene{
    private double _base, _hight, _area;
    public scene(double base1 = 0.0,double hight = 0.0){
        this._base = base1;
        this._hight = hight;
        if(_base == _hight && _base == (double)0.0) _area = 0.0;
        else _area = _base * _hight;
    }
    public void setBase(double base1){
        this._base = base1;
    }
    public void setHight(double hight){
        this._hight = hight;
    }
    public Pair<double,double> getSceneSizeX(){
        return new Pair<double,double>(this._base, (-1)*this._base);
    }
    public Pair<double,double> getSceneSizeY(){
        return new Pair<double,double>(this._hight,(-1)*this._hight);
    }
    public void moveObject(double x_position, double y_position,figure<double> item){
        var positionX = getSceneSizeX();
        var positionY = getSceneSizeY();
        if((x_position <= positionX.first && x_position >= positionX.second) && (y_position <= positionY.first && y_position >= positionY.second) && _area >= item.getArea()){
            item.setXPosition(x_position);
            item.setYPosition(y_position);
        }else{
            Console.WriteLine("Error: Out of range");
        }
    }
}
public class main{
    static void Main(){
        square<double> square = new square<double>(12);
        circle<double> circle = new circle<double>(12);
        rectangle<double> rectangle = new rectangle<double>(12,32);
        triangle<double> triangle = new triangle<double>(12,43);
        List<figure<double>> list = new List<figure<double>>();
        list.Add(square);
        list.Add(circle);
        list.Add(triangle);
        list.Add(rectangle);
        scene newScene = new scene(200,200);
        foreach(var i in list){
            Console.WriteLine("Where do you want to move the first object?");
            Console.WriteLine("X position:");
            double x = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Y position:");
            double y = Convert.ToDouble(Console.ReadLine());
            newScene.moveObject(x,y,i);
        }
        int j = 0;
        foreach(var i in list){
            Console.WriteLine("These are the new position:");
            Console.WriteLine((j++) +") X position: " + i.getXPosition() + " Y position: " + i.getYPosition());
        }
    }
}