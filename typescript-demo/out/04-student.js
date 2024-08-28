import { callMe, PI } from "./04-istudent";
import * as pe from "./02-person";
class Student {
    showData() {
        callMe();
        console.log(`Student Id: ${this.studentId}`);
        console.log(PI);
        let p = new pe.Person();
        console.log(pe.radius);
    }
}
let student = new Student();
student.studentId = "1234123";
student.showData();
