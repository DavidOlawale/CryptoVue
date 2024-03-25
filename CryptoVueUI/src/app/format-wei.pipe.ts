import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'formatWei',
  standalone: true
})
export class FormatWeiPipe implements PipeTransform {

  transform(value: unknown, ...args: unknown[]): unknown {
    return null;
  }

}
