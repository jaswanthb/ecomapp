import { Directive, ElementRef, HostListener, Input } from '@angular/core';

@Directive({
  selector: '[appFavs]',
  standalone: true
})
export class FavsDirective {
  private isLiked: boolean = false;

  @Input("appFavs")
  color: string | undefined;

  constructor(private ele: ElementRef) {
    console.log(this.ele.nativeElement)

    this.update();
  }

  @HostListener('click')
  onLikeClick() {
    this.update();
  }

  @HostListener('mouseover')
  onLikeMouseOver() {
    this.ele.nativeElement.style.color = "pink"
  }

  @HostListener('mouseout')
  onLikeMouseOut() {
    this.ele.nativeElement.style.color = "brown"
  }

  update() {
    this.isLiked = !this.isLiked;
    if (this.isLiked) {
      this.ele.nativeElement.value = "UnLike";
      this.ele.nativeElement.style.color = this.color;
    }
    else {
      this.ele.nativeElement.value = "Like";
      this.ele.nativeElement.style.color = this.color;
    }
  }

}
