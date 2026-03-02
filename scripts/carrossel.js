document.addEventListener("DOMContentLoaded", () => {
    const track = document.getElementById('track');
    const prevBtn = document.getElementById('prevBtn');
    const nextBtn = document.getElementById('nextBtn');
    
    // Trava de segurança contra cliques múltiplos
    let isAnimating = false; 

    const updateActiveSlide = () => {
        const slides = Array.from(track.children);
        const trackCenter = track.getBoundingClientRect().left + (track.offsetWidth / 2);
        
        let closestSlide = slides[0];
        let closestDistance = Infinity;

        slides.forEach(slide => {
            const slideRect = slide.getBoundingClientRect();
            const slideCenter = slideRect.left + (slideRect.width / 2);
            const distance = Math.abs(trackCenter - slideCenter);

            if (distance < closestDistance) {
                closestDistance = distance;
                closestSlide = slide;
            }
        });

        slides.forEach(s => s.classList.remove('active'));
        closestSlide.classList.add('active');
    };

    // Atualiza via swipe no mobile
    track.addEventListener('scroll', () => {
        if (!isAnimating) window.requestAnimationFrame(updateActiveSlide);
    });

    nextBtn.addEventListener('click', () => {
        if (isAnimating) return; // Se a animação tá rolando, ignora o clique
        isAnimating = true;

        const slideWidth = track.firstElementChild.offsetWidth;
        const gap = parseFloat(getComputedStyle(track).gap) || 0; 

        // 1. Rola suavemente para o próximo elemento
        track.scrollBy({ left: slideWidth + gap, behavior: 'smooth' });

        // 2. Espera o scroll nativo terminar (aprox 400ms) para fazer a mágica no DOM
        setTimeout(() => {
            track.style.scrollBehavior = 'auto'; // Remove a suavidade temporariamente
            
            // Tira o primeiro elemento e joga no final
            track.appendChild(track.firstElementChild); 
            
            // Puxa o scroll para trás invisivelmente para compensar o buraco do elemento removido
            track.scrollLeft -= (slideWidth + gap); 
            
            void track.offsetWidth; // Força o navegador a renderizar o cálculo (Reflow)
            
            track.style.scrollBehavior = 'smooth'; // Devolve a suavidade
            updateActiveSlide();
            isAnimating = false; // Libera o botão para o próximo clique
        }, 400); 
    });

    prevBtn.addEventListener('click', () => {
        if (isAnimating) return;
        isAnimating = true;

        const slideWidth = track.firstElementChild.offsetWidth;
        const gap = parseFloat(getComputedStyle(track).gap) || 0;

        // 1. Remove a suavidade e prepara o DOM ANTES de rolar
        track.style.scrollBehavior = 'auto';
        
        // Tira o último elemento e joga no começo
        track.prepend(track.lastElementChild); 
        
        // Empurra o scroll pra frente invisivelmente para você não ver a inserção
        track.scrollLeft += (slideWidth + gap); 
        
        void track.offsetWidth; // Força o Reflow

        // 2. Devolve a suavidade e rola para trás visualmente
        track.style.scrollBehavior = 'smooth';
        track.scrollBy({ left: -(slideWidth + gap), behavior: 'smooth' });

        setTimeout(() => {
            updateActiveSlide();
            isAnimating = false;
        }, 400);
    });

    // Inicia o estado central corretamente
    updateActiveSlide();
});