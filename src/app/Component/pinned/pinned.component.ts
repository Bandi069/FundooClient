import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { Note } from 'src/app/models/notes.model';
import { NoteServicesService } from 'src/app/Service/note-services.service';

@Component({
  selector: 'app-pinned',
  templateUrl: './pinned.component.html',
  styleUrls: ['./pinned.component.scss']
})
export class PinnedComponent implements OnInit {
  @Input() notes: any;
  note: Note = new Note();
  @Output() output: EventEmitter<any> = new EventEmitter();
  constructor(private noteService: NoteServicesService) { }

  ngOnInit() {
  }
  pin(noteId: number) {
    this.noteService.updatePin(noteId).subscribe(Response => {
      console.log(Response);
      this.output.emit("ok");
    });

  }
  unpin(noteId: number) {
    this.noteService.updateUnPin(noteId).subscribe(Response => {
      console.log(Response);
      this.output.emit("ok");
    });
  }

}

