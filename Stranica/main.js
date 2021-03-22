import { Zoo } from "./zooVrt.js"

fetch("https://localhost:44348/TipStanista/").then(p => {
    p.json().then(data => {
        var stanista = data.map(x => x.naziv);
		fetch("https://localhost:44348/ZooVrt/").then(p => {
    p.json().then(data => {
        data.forEach(zoo => {
            const zooVrt = new Zoo(zoo, stanista);
			zooVrt.crtaj(document.body);
        });
    });
});
    });
});