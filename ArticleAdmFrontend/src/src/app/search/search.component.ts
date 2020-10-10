import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'article-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
  @Input() is_visible: boolean;

  constructor() { 
  }

  ngOnInit(): void {
  }

}
