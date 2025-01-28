import { FieldsViewModel } from "./FieldsViewModel";

export interface TableViewModel {
    columns: FieldsViewModel[];
    data: any[];
    showActions: boolean;
}