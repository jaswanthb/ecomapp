import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'mypipe',
  standalone: true
})
export class MypipePipe implements PipeTransform {

  transform(value: unknown, ...args: unknown[]): unknown {
    //console.log("abcder")
    let val = value as string; // Actual value productId

    let char = args[1] as string; // input from user
    let prefix = args[0] as string; // input from user
    let newVal = val.toString().padStart(9, char);

    console.log(args[2]);


    return prefix + newVal;
  }

}
