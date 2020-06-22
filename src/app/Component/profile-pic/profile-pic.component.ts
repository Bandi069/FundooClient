import { Component, OnInit, Inject, Input } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { NoteServicesService } from 'src/app/Service/note-services.service';
import { ImageCroppedEvent } from 'ngx-image-cropper';
import { Note } from 'src/app/models/notes.model';
import { AccountService } from 'src/app/Service/account.service';
@Component({
  selector: 'app-profile-pic',
  templateUrl: './profile-pic.component.html',
  styleUrls: ['./profile-pic.component.scss']
})
export class ProfilePicComponent implements OnInit {

  value: boolean = false;
  imageChangedEvent: any = '';
  croppedImage: any = '';
  //id:any='';
  @Input() notes: Note = new Note();
  //ImageCroppedEvent:any = '';
  
  constructor(private noteserviceobj: NoteServicesService,
    private accountserv: AccountService,
    private snackbar: MatSnackBar,
    @Inject(MAT_DIALOG_DATA) public data: any,
    public dialogRef: MatDialogRef<ProfilePicComponent>) { }

  ngOnInit() {
  }
  //debugger;
  fileChangeEvent(event: any): void {
    debugger;
    this.imageChangedEvent = event;
  }
  imageCropped(event: ImageCroppedEvent) {
    debugger;
    this.croppedImage = event.base64;
  }
  selectFiles($event) {
    debugger;
    this.imageChangedEvent = $event;
  }
  changevalue() {
    this.value = true;
  }
  addImage(croppedImage) {
    debugger;
    console.log("Profile picture", croppedImage); debugger;
    // this.noteserviceobj.uploadImage(this.notes.id, croppedImage).subscribe(response => {
      this.accountserv.profilepic(croppedImage).subscribe(response => {
      debugger;
      console.log(response);
    },
      error => {
        debugger;
        this.snackbar.open("Profile pic update failed", "", { duration: 2000, horizontalPosition: 'start' });
      })
  }
}
