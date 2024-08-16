//Anything that can be exported can only be imported
//interface, class, function and variables can be exported
//Use export keyword to export any object
//use import keyword to refer object to the ts
//to implement an interface use implements keyword

import { IStudent, callMe, PI } from "./04-istudent";
import { Person } from "./02-person"

class Student implements IStudent {
    studentId: string;

    showData() {
        callMe();
        console.log(`Student Id: ${this.studentId}`); // String interpolation
        console.log(PI);
        let p = new Person();
    }
}

let student = new Student();
student.studentId = "1234123";
student.showData();