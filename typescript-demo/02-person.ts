//class, constructor, parameterized constructor, inheritance, handling parameters in constructor
//initialing derived class constructor and parent constructor

export class Person {
    personId: number; // default access modifier is public
    personName: string | undefined; //Union type
    personEmail: string;

    // constructor(){
    //     this.personId = 1;
    //     this.personName = "jaswanth";
    //     this.personEmail = "jas@gmail.com"
    // }

    constructor(pid?: number, pName?: string, pEmail?: string) {
        if (pid != undefined) {
            this.personId = pid;
            this.personName = pName; // Resolved with union type
            this.personEmail = pEmail ?? "jaswa@gmail.com"; // Resolved with null check
        }
        else {
            this.personId = 1;
        }
    }

    showDetails() {
        console.log(this.personId);
        console.log(this.personName);
        console.log(this.personEmail);
    }

}

var p = new Person();
p.showDetails();

var p1 = new Person(200, "Jaswanth");
p1.showDetails();

var p2 = new Person(300, "abc", "abc@test.com");
p2.showDetails();

class Employee extends Person { // Employee class is a derived class
    isActive: boolean;

    // to run derived/child class constructor, it should first run base class constructor
    constructor(pId?: number, pName?: string, pEmail?: string) {
        super(pId, pName, pEmail);//To run base class constructor use super keyword
    }
}

let employee = new Employee(1002, "abc", "abc@gmail.com");
employee.showDetails();

let employee1 = new Employee();
employee1.showDetails();