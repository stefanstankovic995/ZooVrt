import {Lokacija} from './lokacija.js';

export class Zoo{
	    constructor(zoo, tipoviStanista) {
        this.id = zoo.id;
        this.naziv = zoo.naziv;
        this.n = zoo.n;
        this.m = zoo.m;
        this.kapacitet = zoo.kapacitet;
		this.lokacije = Array.from({length:zoo.m}, (_,i) => Array.from({length:zoo.n}, (_,j) => new Lokacija(0, i, j, null,
							0, zoo.kapacitet, null)));
		zoo.lokacije.forEach(x => {
			this.lokacije[x.x][x.y] = 
			new Lokacija(x.id, x.x, x.y, x.vrsta, x.zbir, zoo.kapacitet, zoo.staniste);
		});
		this.tipoviStanista = tipoviStanista;
		
		console.log(this);
    }
	
	crtaj(host) {
        let glavni = document.createElement("div");
        glavni.classList.add("kontejner");
		this.crtajFormu(glavni);
		this.crtajLokacije(glavni);
        host.appendChild(glavni);
    }
    crtajFormu(host) {

        let glavni = document.createElement("div");
        glavni.className = "kontForma";
        host.appendChild(glavni);

        var labela = document.createElement("h3");
        labela.innerHTML = "Unos zivotinja";
        glavni.appendChild(labela);

        labela = document.createElement("label");
        labela.innerHTML = "Ime vrste";
        glavni.appendChild(labela);

        let input = document.createElement("input");
        input.className = "vrsta";
        glavni.appendChild(input);


        labela = document.createElement("label");
        labela.innerHTML = "Kolicina";
        glavni.appendChild(labela);

        input = document.createElement("input");
        input.className = "kolicina";
        input.type = "number";
        glavni.appendChild(input);


        let opcija = null;
        let divRb = null;
        this.tipoviStanista.forEach((staniste, index) => {
            divRb = document.createElement("div");
            opcija = document.createElement("input");
            opcija.type = "radio";
            opcija.name = this.naziv;
            opcija.value = this.naziv;

            labela = document.createElement("label");
            labela.innerHTML = staniste;


            divRb.appendChild(opcija);
            divRb.appendChild(labela);
            glavni.appendChild(divRb);
        })


        divRb = document.createElement("div");
        let selX = document.createElement("select");
        labela = document.createElement("label");
        labela.innerHTML = "X:"
        divRb.appendChild(labela);
        divRb.appendChild(selX);

        for (let i = 0; i < this.m; i++) {
            opcija = document.createElement("option");
            opcija.innerHTML = i;
            opcija.value = i;
            selX.appendChild(opcija);
        }

        glavni.appendChild(divRb);


        let selY = document.createElement("select");
        labela = document.createElement("label");
        labela.innerHTML = "Y:"
        divRb.appendChild(labela);
        divRb.appendChild(selY);

        for (let i = 0; i < this.n; i++) {
            opcija = document.createElement("option");
            opcija.innerHTML = i;
            opcija.value = i;
            selY.appendChild(opcija);
        }

        glavni.appendChild(divRb);

        const dugme = document.createElement("button");
        dugme.innerHTML = "Dodaj zivotinje";
        glavni.appendChild(dugme);

        dugme.onclick = (ev) => {
            const vrsta = this.kontejner.querySelector(".vrsta").value;
            const kolicina = parseInt(this.kontejner.querySelector(".kolicina").value);
            const tip = this.kontejner.querySelector(`input[name='${this.naziv}']:checked`);

            if (tip == null)
                alert("Molimo Vas izaberite tip stnaista");

            let x = parseInt(selX.value);
            let y = parseInt(selY.value);

            // Ovde je zamenjena kompletna provera upisa, koja je prebačena na server. Uvek je bolje takve promene vršiti na serveru.
            /*let potenzijalnaLok = this.lokacije.find(lok => lok.vrsta == vrsta
                && lok.kapacitet + kolicina <= this.kapacitet
                && (lok.x != x || lok.y != y));
            if (potenzijalnaLok)
                alert("Postoji nepopunjena lokacija sa navedenom vestom! Lokacija je (" + potenzijalnaLok.x + "," + potenzijalnaLok.y + ")");
            else
                this.lokacije[x * this.n + y].azurirajLokaciju(vrsta, kolicina, tip.value, x, y);*/
            fetch("https://localhost:5001/Zoo/UpisLokacije/" + this.id, {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify({
                    vrsta: vrsta,
                    kapacitet: kolicina,
                    maxKapacitet: this.kapacitet,
                    tip: tip.value,
                    x: x,
                    y: y,

                })
            }).then(p => {
                if (p.ok) {
                    this.lokacije[x * this.n + y].azurirajLokaciju(vrsta, kolicina, tip.value, x, y);
                }
                else if (p.status == 400) {
                    // BadRequest vraća lokaciju kao json. Zato čitamo taj json ispod i upisujemo u greskaLokacija, koju ispisujemo u alert-u.
                    const greskaLokacija = { x: 0, y: 0 };
                    p.json().then(q => {
                        greskaLokacija.x = q.x;
                        greskaLokacija.y = q.y;
                        alert("Postoji nepopunjena lokacija sa navedenom mestom! Lokacija je (" + greskaLokacija.x + "," + greskaLokacija.y + ")");
                    });
                }
                else {
                    alert("Greška prilikom upisa.");
                }
            }).catch(p => {
                alert("Greška prilikom upisa.");
            });
        }
    }

    crtajLokacije(host) {
        let glavni = document.createElement("div");
        glavni.className = "kontLokacije";

        for (let i = 0; i < this.m; i++) {
			  
            let lokDiv = document.createElement("div");
            lokDiv.className = "red";
            for (let j = 0; j < this.n; j++) {
                this.lokacije[i][j].crtaj(lokDiv);
            }
			glavni.appendChild(lokDiv);
        }
		host.appendChild(glavni);
    }
}