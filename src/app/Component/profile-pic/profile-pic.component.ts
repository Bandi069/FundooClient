import { Component, OnInit, Inject } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { NoteServicesService } from 'src/app/Service/note-services.service';

@Component({
  selector: 'app-profile-pic',
  templateUrl: './profile-pic.component.html',
  styleUrls: ['./profile-pic.component.scss']
})
export class ProfilePicComponent implements OnInit {
  picLink : any;
  imageChangedEvent: any = '';
 flag : boolean = false;
croppedImage: any = '';
  constructor(private noteserviceobj:NoteServicesService,
    private snackbar:MatSnackBar,
    @Inject(MAT_DIALOG_DATA) public data: any,
    public dialogRef: MatDialogRef<ProfilePicComponent>) { }

  ngOnInit() {
  }
  onSelectedFile(event) {
    this.imageChangedEvent = event;
    }
    // imageCropped(event: imageCroppedEvent) {
    // this.croppedImage = event.file;
    // }

    changeFlag(){
      this.flag = true;
    }
    debugger;
    addImage(croppedImage){
      debugger;
      console.log("Cropped image: ",croppedImage);
     this.noteserviceobj.uploadImage(croppedImage, 'image-upload').subscribe(
       data => {
          this.picLink = data['imgUrl'];
         this.data.updateProfilePic(this.picLink);
       },
       error => {
        debugger;
         this.snackbar.open("Error in uploading profile pic","",{duration: 2000,horizontalPosition:'start'});
       }
     )

   }
  

}
