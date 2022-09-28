import { Component, ElementRef, OnInit } from '@angular/core';
import {
  Observable,
  fromEvent,
  debounce,
  debounceTime,
  filter,
  map,
  switchMap,
} from 'rxjs';
import { AllegroService } from '../services/allegro.service';

@Component({
  selector: 'app-offers',
  templateUrl: './offers.component.html',
  styleUrls: ['./offers.component.scss'],
})
export class OffersComponent implements OnInit {
  constructor(private el: ElementRef, private allegroService: AllegroService) {}

  ngOnInit(): void {
    fromEvent(this.el.nativeElement, 'keyup')
      .pipe(
        debounceTime(500),
        //extract input value
        map((e: KeyboardEvent) => (e.target as HTMLInputElement).value),
        filter((val: string) => val.length >= 3),
        switchMap(searchPhrase=>this.allegroService.getSearchProducts(searchPhrase))
      )

      .subscribe((data) => console.log('bang', data));
  }
}
