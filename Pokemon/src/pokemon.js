async function fecthPokemonList() {
  const pokemonList = document.getElementById("pokemonList");
  for (let i = 1; i <= 200; i++) {
    try {
      const response = await fetch(`https://pokeapi.co/api/v2/pokemon/${i}`);
      const pokemon = await response.json();

      const speciesResponse = await fetch(pokemon.species.url);
      const speciesData = await speciesResponse.json();
      const description = speciesData.flavor_text_entries
        .find((entry) => entry.language.name === "es")
        .flavor_text.replace(/\f/g, " ");

      const card = document.createElement("div");
      card.className =
        "bg-white border-2 border-pink-200 hover:border-indigo-400 rounded-lg shadow-lg p-4 text-center hover:scale-105 transition transform duration-300";
      card.setAttribute("data-name", pokemon.name);

      const types = pokemon.types
        .map(
          (t) =>
            `<span class="bg-indigo-100 text-indigo-500 hover:text-pink-500 hover:bg-pink-100 font-mono px-2 rounded mx-1">${t.type.name.toUpperCase()}</span>`
        )
        .join(" ");

      card.innerHTML = `
              <img src="${
                pokemon.sprites.other["official-artwork"].front_default
              }" alt="${pokemon.name}" class="w-32 mx-auto mb-4" />
              <h2 class="text-xl font-bold text-indigo-400 hover:text-pink-400 font-mono">${pokemon.name.toUpperCase()}</h2>
              <p class="text-gray-700 font-mono">Weight: ${pokemon.weight}</p>
              <p class="text-gray-700 font-mono">Height: ${pokemon.height}</p>
              <p class="text-gray-700 font-mono">Attack: ${
                pokemon.stats[1].base_stat
              }</p>
              <p class="text-gray-700 font-mono">Defense: ${
                pokemon.stats[2].base_stat
              }</p>
              <div class="mt-2">${types}</div>
              <div class="flex justify-center items-center mt-4 cursor-pointer" id="toggle-desc-${i}">
                <i class="fa-solid fa-arrow-down text-pink-200 text-2xl transition-transform duration-300"></i>
              </div>
              <p class="text-gray-600 mt-2 hidden" id="desc-${i}">${description}</p>
              `;
              
              card.querySelector(`#toggle-desc-${i}`)
              .addEventListener("click", function () {
                const desc = document.getElementById(`desc-${i}`);
                desc.classList.toggle("hidden");
                this.classList.toggle("rotate-180"); 
            });

      pokemonList.appendChild(card);
    } catch (error) {
      console.error("Error al obtener Pokemon:" + error);
    }
  }
}

function filterPokemon() {
  const searchInput = document
    .getElementById("searchInput")
    .value.toLowerCase();
  const cards = document.querySelectorAll("#pokemonList > div");

  cards.forEach((card) => {
    const name = card.getAttribute("data-name");
    if (name.includes(searchInput)) {
      card.classList.remove("hidden");
    } else {
      card.classList.add("hidden");
    }
  });
}

fecthPokemonList();
