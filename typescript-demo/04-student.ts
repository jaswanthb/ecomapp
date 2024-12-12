//Anything that can be exported can only be imported
//interface, class, function and variables can be exported
//This brings to the concept of module
//Use export keyword to export any object
//use import keyword to refer object to the ts
//to implement an interface use implements keyword

import { IStudent, callMe, PI} from "./04-istudent";
//import { Person, radius } from "./02-person"
import * as pe from "./02-person" // If you need all exportable object in this class use * with alias

class Student implements IStudent {
    studentId: string;

    showData() {
        callMe();
        console.log(`Student Id: ${this.studentId}`); // String interpolation
        console.log(PI);
        let p = new pe.Person(); // Use alias name to call exported objects
        console.log(pe.radius);
    }
}

let student = new Student();
student.studentId = "1234123";
student.showData();