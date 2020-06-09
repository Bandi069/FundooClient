import { Component, OnInit, Inject } from '@angular/core';
import { Label } from 'src/app/models/label.model';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NoteServicesService } from 'src/app/Service/note-services.service';
import { debug } from 'util';

@Component({
  selector: 'app-label',
  templateUrl: './label.component.html',
  styleUrls: ['./label.component.scss']
})
export class LabelComponent implements OnInit {

  allLabelNames: any;
  edit: boolean = false;
  nameLabel: any;
  labelname: Label = new Label();
  constructor(@Inject(MAT_DIALOG_DATA) public data: any, private noteService: NoteServicesService,
    public dialogRef: MatDialogRef<LabelComponent>) { }

  ngOnInit(): void {
  }

  createLabels(data) {
    if (data != null && data != '') {
      this.labelname.labelName = data;
      if (this.data.labels.labelId == undefined){
        this.labelname.noteId=null;
        this.dialogRef.close({ createLabel: this.labelname });
      }
      else {
        this.labelname.noteId = this.data.labels.labelId;
        this.dialogRef.close({ editLabel: this.labelname });
      }
      this.labelname.labelName = data;
      this.noteService.addLabel(this.labelname).subscribe(Response => {
        console.log(Response);
      })

      console.log(data);

    }
    else {
      console.log("Label is empty");
    }
  }


  deleteLabel(id) {
    this.labelname.labelId = id;
    this.dialogRef.close({ delteLabel: this.labelname });
  }

  editLabel() {
    this.edit = true;
  }
}
