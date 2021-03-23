import {Lokacija} from './lokacija.js';

export class Zoo{
	    constructor(zoo, tipoviStanista, refreshMethod) {
        this.id = zoo.id;
        this.naziv = zoo.naziv;
        this.n = zoo.n;
        this.m = zoo.m;
        this.kapacitet = zoo.kapacitet;
		this.lokacije = Array.from({length:zoo.m}, (_,i) => Array.from({length:zoo.n}, (_,j) => new Lokacija(0, i, j, "Prazno",
							0, zoo.kapacitet, null)));
		zoo.lokacije.forEach(x => {
			this.lokacije[x.x][x.y] = 
			new Lokacija(x.id, x.x, x.y, x.vrsta, x.zbir, zoo.kapacitet, x.staniste);
		});
		this.tipoviStanista = tipoviStanista;
		this.glavni = null;
		this.refreshMethod = refreshMethod;
    }
	
	crtaj(host) {
        this.glavni = document.createElement("div");
        this.glavni.classList.add("kontejner");
		this.crtajFormu(this.glavni);
		this.crtajLokacije(this.glavni);
        host.appendChild(this.glavni);
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
            opcija.name = staniste.naziv;
            opcija.value = staniste.id;

            labela = document.createElement("label");
            labela.innerHTML = staniste.naziv;


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
            const vrstaZivotinje = this.glavni.querySelector(".vrsta").value;
            const kolicina = parseInt(this.glavni.querySelector(".kolicina").value);
            const staniste = this.glavni.querySelector(`input:checked`);
			
            if (staniste == null)
                alert("Molimo Vas izaberite tip stnaista");

            let x = parseInt(selX.value);
            let y = parseInt(selY.value);
			const lokId = this.lokacije[x][y].id;
        
            fetch("https://localhost:44348/ZooVrt/IzmeniLokaciju/" + this.id, {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify({
					id: lokId,
                    vrsta: vrstaZivotinje,
                    zbir: kolicina,
                    staniste: { id: parseInt(staniste.value), naziv: staniste.name},
                    x: x,
                    y: y,

                })
            }).then(p => {
                if (p.ok) {
                    alert("Uspešno sacuvane izmene!");
					this.refreshMethod();
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