import { Component, OnInit, OnChanges, Input, output,ViewChild, SimpleChanges } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { TableViewModel } from './Models/TableViewModel';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrl: './table.component.css'
})
export class TableComponent implements OnInit, OnChanges{
  @Input() table!: TableViewModel;

  read = output<any>();
  create = output<any>();

  displayedColumns: string[] = [];
  dataSource = new MatTableDataSource<any>();

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  ngOnInit() {
    if (this.table) {
      this.loaderTable();
    }
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.loaderTable();
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  readRow(row: any){
    this.read.emit(row);
  }

  createRow(row: any){
    this.create.emit(row);
  }

  loaderTable():void{
    let columns = this.table.columns.map(column => column.key);
      if (this.table.showActions) {
        this.displayedColumns = [...columns, 'read', 'create']
      } else {
        this.displayedColumns = columns
      }
      this.dataSource.data = this.table.data;
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
  }
}
