export interface IStudent{
    showData();
}

export function callMe(){ // Function, class, variables or interface can be exported
    console.log("Call me");

}

export const PI: number = 3.14;

export const radius:string="Circle";

function privateFn(){

}

privateFn();
console.log(radius);