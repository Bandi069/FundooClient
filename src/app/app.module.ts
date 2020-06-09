import { BrowserModule } from '@angular/platform-browser';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppComponent } from './app.component';
import { RegisterComponent } from './Component/register/register.component';
import { LoginComponent } from './Component/login/login.component';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { HttpClientModule } from '@angular/common/http';
import { AccountService } from './Service/account.service';
import { RouterModule, Router } from '@angular/router';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { ForgotPasswordComponent } from './Component/forgot-password/forgot-password.component';
import { ResetPasswordComponent } from './Component/reset-password/reset-password.component';
import { DashBoardComponent } from './Component/dash-board/dash-board.component';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatDividerModule } from '@angular/material/divider';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatListModule } from '@angular/material/list';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { CreateNoteComponent } from './Component/create-note/create-note.component';
import { IconsComponent } from './Component/icons/icons.component';
import { PinnedComponent } from './Component/pinned/pinned.component';
import { NotesComponent } from './Component/notes/notes.component';
import { DisplayComponent } from './Component/display/display.component';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MatChipsModule } from '@angular/material/chips';
import { LabelComponent } from './Component/label/label.component';
import { LabelNoteComponent } from './Component/label-note/label-note.component';
import { UpdateNoteComponent } from './Component/update-note/update-note.component';
import { CollaboratorComponent } from './Component/collaborator/collaborator.component';
import { ProfilePicComponent } from './Component/profile-pic/profile-pic.component';
import { MatDialogRef, MatDialogModule } from '@angular/material/dialog';
import { SearchComponent } from './Component/search/search.component';

@NgModule({
  declarations: [
    AppComponent,
    RegisterComponent,
    LoginComponent,
    LoginComponent,
    RegisterComponent,
    ForgotPasswordComponent,
    ResetPasswordComponent,
    DashBoardComponent,
    CreateNoteComponent,
    IconsComponent,
    PinnedComponent,
    NotesComponent,
    DisplayComponent,
    LabelComponent,
    LabelNoteComponent,
    UpdateNoteComponent,
    CollaboratorComponent,
    ProfilePicComponent,
    SearchComponent

  ],
  imports: [
    BrowserModule,
    FlexLayoutModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    MatFormFieldModule,
    MatTooltipModule,
    MatExpansionModule,
    MatChipsModule,
    MatSidenavModule,
    FormsModule,
    MatButtonToggleModule,
    MatDividerModule,
    MatSelectModule,
    MatCardModule,
    MatNativeDateModule,
    MatDatepickerModule,
    MatToolbarModule,
    ReactiveFormsModule,
    MatInputModule,
    MatButtonModule,
    MatListModule,
    MatMenuModule,
    MatIconModule,
    MatDialogModule,
    HttpClientModule,
    MatSnackBarModule,
    RouterModule.forRoot([])
  ],
  entryComponents: [LabelComponent, UpdateNoteComponent, CollaboratorComponent,ProfilePicComponent],
  providers: [AccountService],
  bootstrap: [AppComponent],
  schemas: [
    CUSTOM_ELEMENTS_SCHEMA,
  ]
})
export class AppModule {
}
