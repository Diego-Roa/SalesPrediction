import { AbstractControl, ValidationErrors } from '@angular/forms';

/**
 * Validador de porcentaje para que cumpla con:
 * Maximo 3 decimales
 * Debe estar entre 0 y 1
 * Permitir solo numeros y separador deciaml
 * 
 * @param control 
 * @returns 
 */
export function percentajeValidator(
  control: AbstractControl
): ValidationErrors | null {
  let value = control.value;

  if (typeof value === 'string') {
    value = value.replace(/[^0-9.]/g, '');
    const parts = value.split('.');
    if (parts.length > 2) {
      value = parts[0] + '.' + parts[1];
    }
    if (parts[1]?.length > 3) {
      value = parts[0] + '.' + parts[1].slice(0, 3);
    }
    const numericValue = parseFloat(value);
    if (numericValue > 1) {
      value = '1';
    }
  }
  const numericValue = parseFloat(value);
  if (isNaN(numericValue) || numericValue < 0 || numericValue > 1) {
    return { percentajeInvalid: true };
  }

  return null;
}
