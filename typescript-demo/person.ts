//class, constructor, parameterized constructor, inheritance, handling parameters in constructor
//initialing derived class constructor and parent constructor

class Person {
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
            this.personName = pName;
            this.personEmail = pEmail ?? "jaswa@gmail.com";
        }
        else{
            this.personId = 1;
        }

    }

    //constructor();
    //constructor(pId?: number, pName?: string);

    // constructor(pId?: number, pName?: string, pEmail?: string) {

    //     if (pId != undefined) {
    //         this.personId = pId;
    //         this.personName = pName;
    //         this.personEmail = pEmail ?? "empty";
    //     }

    // }

    showDetails() {
        console.log(this.personId);
        console.log(this.personName);
        console.log(this.personEmail);
    }

}


// var p = new Person();
// p.showDetails();

// var p1 = new Person(200,"aravind");
// p1.showDetails();

// var p2 = new Person(300,"abctest","abc@test.com");
// p2.showDetails();

// let person = new Person(103, "jas");
// person.showDetails();

class Employee extends Person { // Employee class is a derived class
    isActive: boolean;


    // constructor(){
    //     super();
    // }
    
    constructor(pId: number, pName:string, pEmail: string) {
        super(pId,pName,pEmail);
    }
}

let employee = new Employee(1002,"abc","abc@gmail.com");
employee.showDetails();


// let employee = new Employee();
// employee.showDetails();