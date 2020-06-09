import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-label-note',
  templateUrl: './label-note.component.html',
  styleUrls: ['./label-note.component.scss']
})
export class LabelNoteComponent implements OnInit {

  param:any;
  constructor(private activatedRoute :ActivatedRoute) { }

  ngOnInit() {
    this.activatedRoute.queryParams.subscribe(params => {
      this.param = params['page'];
    });
  }

}
