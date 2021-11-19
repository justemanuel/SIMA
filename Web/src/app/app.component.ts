import { HttpClient } from '@angular/common/http';
import { Component, ViewChild } from '@angular/core';
import { MatTable, MatTableDataSource } from '@angular/material/table';
import { environment } from '../environments/environment';
import { Registro } from './interfaces/report.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Web';
  recolectando: boolean = false;
  displayedColumns: string[] = [
    "estrellas", "planetas", "satelites",
    "promediodistanciaestrellas",
    "promediodistanciaplanetas",
    "promediodistanciasatelites",
    "promediotamestrellas",
    "promediotamplanetas",
    "promediotamsatelites",
    "promediotemperaturaestrellas",
    "moda"
  ];  

  @ViewChild(MatTable) table: MatTable<Registro> | undefined;
  dataSource = new MatTableDataSource<Registro>();
  
  constructor(private http: HttpClient) {
  }

  onClick() {
    this.recolectando = !this.recolectando;

    if (this.recolectando) {
      this.http.post(environment.apiUrl + '/registro', null)
      .subscribe(() => {
      }, err => console.log('ERROR!', err));
    } else {
      this.http.get<Registro>(environment.apiUrl + '/registro')
      .subscribe(res => {
        this.dataSource.data.push(res);
        this.table?.renderRows();
        console.log(this.dataSource.data);
      }, err => {
        console.log('ERROR!', err);
      });
    }
  }
}
