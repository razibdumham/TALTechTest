import { ChangeDetectorRef, Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-calculate-premium',
  templateUrl: './calculate-premium.component.html'
})
export class CalculatePremiumComponent implements OnInit {
  public calculatePremium: PremiumCalculatorModel;
  
  public calculatorForm = this.formBuilder.group({
    name: '',
    age: '',
    dateOfBirth: '',
    sumInsured: '',
    factor:''
  });
  public httpClient: HttpClient;
  public baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private cdRf: ChangeDetectorRef, private formBuilder: FormBuilder) {
    this.httpClient = http;
    this.baseUrl = baseUrl;
    
  }
  ngOnInit(): void {
    this.httpClient.get<PremiumCalculatorModel>(this.baseUrl + 'CalculatePremium').subscribe(result => {
      this.calculatePremium = result;
      this.cdRf.detectChanges();
    }, error => console.error(error));
    //this.formdata = new FormGroup({
    //  name: new FormControl("Razib")
    //});
  }
  onClickSubmit(event: any) {
    //const formData = new FormData();
    //formData.append('name', this.calculatorForm.get('name').value);
    //formData.append('age', this.calculatorForm.get('age').value);
    //formData.append('dateOfBirth', this.calculatorForm.get('dateOfBirth').value);
    //formData.append('sumInsured', this.calculatorForm.get('sumInsured').value);
    //formData.append('factor', this.calculatorForm.get('factor').value);

    this.calculatePremium.name = this.calculatorForm.get('name').value;
    this.calculatePremium.age = this.calculatorForm.get('age').value;
    this.calculatePremium.dateOfBirth = this.calculatorForm.get('dateOfBirth').value;
    this.calculatePremium.sumInsured = this.calculatorForm.get('sumInsured').value;
    this.calculatePremium.ratingId = event.target.value;

    this.httpClient.post<any>(this.baseUrl + 'CalculatePremium', this.calculatePremium).subscribe(result => {
      this.calculatePremium = result;
      this.cdRf.detectChanges();
    }, error => console.error(error));
  }
}

interface PremiumCalculatorModel {
  name: string;
  age: number;
  dateOfBirth: string;
  occupationTitle: string;
  sumInsured: number;
  ratingId: number;
  factor: number;
  calculatedPremium: number;
  occupations: [];
}
