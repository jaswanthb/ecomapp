/*

//install node
npm i -g typescript // install typescript compiler globally

//npm will resolve the inter dependencies

tsc sample.ts // Compile typescript file
node sample.js //run js file

> tsc .\01-datatypes.ts --target es6 // compile typescript with ecmascript 6 standards, default is es5 

*/

//Data types, let and var

var num: number = 10;
var str: string = "Jas";
var decim: number = 10.004;
var bool: boolean = true;

var anytype: any = "strr";
anytype = 1004;

var dontknow: unknown = "hey";
dontknow = anytype;

console.log(num);
console.log(str);
console.log(decim);
console.log(bool);
console.log(anytype);
console.log(dontknow);

let a1: number = 100; //blocked scope
var b1: number = 200;//global/function scope
if (true) {
    console.log(b1);
    let a1 = 300;
    var b1 = 400;

    console.log(a1);
    console.log(b1);
}

console.log(a1);
console.log(b1);

//Hoisting -- browser moves all the global scoped variables to top but not values assigned

var testvar;

console.log(testvar);//undefined
testvar = 100;
console.log(testvar);//100
