import { Component, OnInit } from '@angular/core';
import { NoteServicesService } from 'src/app/Service/note-services.service';
import { Note } from 'src/app/models/notes.model';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent implements OnInit {
  search: any;
  searchdata:any;
  searchedData: any;
  note: Note = new Note();
  gridView: string = "row";
  constructor(private noteServices: NoteServicesService,
    private route: ActivatedRoute
    ) { }

    
  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.searchedData = params["data"];
      this.notesearching();
    });
  }
  notesearching() {
    console.log(this.searchedData);
    this.noteServices.notesearch(this.searchedData).subscribe(Response => {
      this.searchdata = Response;
      console.log(Response)
    });
  }
}
