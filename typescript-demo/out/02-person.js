export class Person {
    constructor(pid, pName, pEmail) {
        if (pid != undefined) {
            this.personId = pid;
            this.personName = pName;
            this.personEmail = pEmail !== null && pEmail !== void 0 ? pEmail : "jaswa@gmail.com";
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
export const radius = "This is applicable only to circle";
var p = new Person();
p.showDetails();
var p1 = new Person(200, "Jaswanth");
p1.showDetails();
var p2 = new Person(300, "abc", "abc@test.com");
p2.showDetails();
class Employee extends Person {
    constructor(pId, pName, pEmail) {
        super(pId, pName, pEmail);
    }
}
let employee = new Employee(1002, "abc", "abc@gmail.com");
employee.showDetails();
let employee1 = new Employee();
employee1.showDetails();
