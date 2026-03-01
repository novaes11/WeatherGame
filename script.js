document.addEventListener("DOMContentLoaded", () => {
    const track = document.getElementById('track');
    const slides = Array.from(track.children);
    const prevBtn = document.getElementById('prevBtn');
    const nextBtn = document.getElementById('nextBtn');

    // Função para atualizar qual slide tem a classe 'active'
    const updateActiveSlide = () => {
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

        // Remove active de todos e adiciona no mais central
        slides.forEach(s => s.classList.remove('active'));
        closestSlide.classList.add('active');
    };

    // Escuta o scroll nativo (para o mobile)
    track.addEventListener('scroll', () => {
        // Usa requestAnimationFrame para não matar a performance no mobile
        window.requestAnimationFrame(updateActiveSlide);
    });

    // Funções dos botões (Desktop/Tablet)
    nextBtn.addEventListener('click', () => {
        const slideWidth = slides[0].offsetWidth;
        // Pega o gap definido no CSS (1rem = 16px por padrão)
        const gap = parseFloat(getComputedStyle(track).gap) || 0; 
        
        track.scrollBy({
            left: slideWidth + gap,
            behavior: 'smooth'
        });
    });

    prevBtn.addEventListener('click', () => {
        const slideWidth = slides[0].offsetWidth;
        const gap = parseFloat(getComputedStyle(track).gap) || 0;
        
        track.scrollBy({
            left: -(slideWidth + gap),
            behavior: 'smooth'
        });
    });

    // Chama na carga inicial para setar o primeiro ativo corretamente
    updateActiveSlide();
});