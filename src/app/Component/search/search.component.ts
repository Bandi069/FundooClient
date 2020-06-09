import { Component, OnInit } from '@angular/core';
import { NoteServicesService } from 'src/app/Service/note-services.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent implements OnInit {
  AllNotes: any[];
  Search: any = " ";
  values: any = " ";
  constructor(private noteServices: NoteServicesService) { }

  ngOnInit() {
    this.noteServices.notesearch(this.values).subscribe(Response => {
    this.Search = Response
    }
    )
  }
}
