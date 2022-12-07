using System;  
  
class Building {   
  private int Floors;
  private int Area;
  private int Occupants;
  public Building(int Floors = 2, int Area = 1500, int Occupants = 4){
    this.Floors = Floors;
    this.Area = Area;
    this.Occupants = Occupants;
  }
  public void setArea(int Area){
    this.Area = Area;
  }
  public void setFloors(int Floors){
    this.Floors = Floors;
  }
  public void setOccupants(int Occupants){
    this.Occupants = Occupants;
  }
  public int getArea(){
    return this.Area;
  }
  public int getOccupants(){
    return this.Occupants;
  }
  public int getFloors(){
    return this.Floors;
  }
  public int areaPP(){
    return this.Area/Occupants;
  }
}
class BuildingDemo {   
  static void Main() {   
    Building house = new Building();
    int areaPP;
    areaPP = house.areaPP();  
   
    Console.WriteLine("house has:\n  " + 
                      house.getFloors() + " floors\n  " + 
                      house.getOccupants() + " occupants\n  " + 
                      house.getArea() + " total area\n  " + 
                      areaPP + " area per person"); 
  }   
}
