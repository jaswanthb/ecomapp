//array with single datatype
//Arrays with multiple datatypes
//Spread operator

//Run command tsc -init to create typescript config file to control ts settings
//Creates new file called tsconfig.ts
//If you see syntax erros find '"strict": true,' and comment it as this will validate syntax strictly
//find '"outDir": "./",' change the value to './out' to generate the js files in out folder
//find '"removeComments": true,' uncomment it to remove all comments from js files 

let arr: number[] = [1, 2, 3]

let arr1: Array<number | string | boolean> = [1, 2, 3, "jas", "wanth", 5, true];

let arr2: number[] = [1, 3, 5, 7];

let arr3: number[] = [2, 4, 6, ...arr2, ...arr]; // ... is spread operator, used to Merge 1 array into another
//o/p: arra3 = [2,4,6,1,3,5,7,1,2,3]

let arr4: Array<number|string|boolean> = ["a","bc",5,1, ...arr1];
console.log(arr4);


//If input parameters are expected
function add(a, b) {
    let result = a + b;
    console.log(`Result 1 = ${result}`)
}

add(10, 20)

//If input parameters are not known 
function addMultiple(a:number, b:number, ...nums:number[]) { // accept input using spread operator
    let result = a + b;
    for (let n of nums) {
        result = result + n;
    }
    console.log(`Result 2 = ${result}`)
}

addMultiple(10, 20, 34, 45, 56, 49, 20,30,56,85, 98,89,101, 152,); // pass as many numbers as needed instead of array