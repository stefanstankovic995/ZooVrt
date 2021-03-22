import { TipStanista } from "./tipStanista.js";

export class Lokacija {
	constructor(id, x, y, vrsta, zbir, maxZbir, staniste){
		this.id = id;
		this.x = x;
        this.y = y;
		this.vrsta = vrsta;
		this.zbir = zbir;
        this.maxZbir = maxZbir;
		if(staniste){
			this.staniste = new TipStanista(lokacija.staniste);
		}
		else{
			this.staniste = staniste
		}
	}
	
	crtaj(host) {
        let glavni = document.createElement("div");
        glavni.className = "lok";
        glavni.innerHTML = "Prazno, " + this.zbir + ", (" + this.maxZbir + ")";
        glavni.style.backgroundColor = this.vratiBoju();
        host.appendChild(glavni);

    }
	
	vratiBoju() {
        if (!this.tip)
            return "pink";
        else
            return "blue";
    }
}