import { Component, OnInit, Output, EventEmitter, Inject, Input } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Note } from 'src/app/models/notes.model';

@Component({
  selector: 'app-update-note',
  templateUrl: './update-note.component.html',
  styleUrls: ['./update-note.component.scss']
})
export class UpdateNoteComponent implements OnInit {
  @Input() labels:any;
  @Input() collaborator:any;
  @Output() output: EventEmitter<any> = new EventEmitter();
  constructor(@Inject(MAT_DIALOG_DATA) public data: any,
  public dialogRef: MatDialogRef<UpdateNoteComponent>) { }

  note: Note = new Note();
  ngOnInit(): void {
  }
  updateNote(title, description, noteId) {
    this.note.id = noteId;
    this.note.description = description;
    this.note.title = title;
    this.note.email=localStorage.getItem('Email');
    this.dialogRef.close({ updateData: this.note });
  }

  outputFunction(value) {
    this.dialogRef.close({ resu: value });
  }

}
