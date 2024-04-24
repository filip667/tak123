using MediatR;
using PersonalStudio.Application.Domain.Entities;
using PersonalStudio.Application.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PersonalStudio.Application.Services.Commands.UpdateImagePrimaryCommand
{
    public class UpdateImagePrimaryCommand : IRequest<Unit>
    {
        public Guid ImageId { get; set; }
    }

    public class ImagePrimaryCommandHandler : IRequestHandler<UpdateImagePrimaryCommand, Unit>
    {
        private readonly IImageRepository _imageRepository;

        public ImagePrimaryCommandHandler(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task<Unit> Handle(UpdateImagePrimaryCommand request, CancellationToken cancellationToken)
        {
            // Pobierz obrazek z repozytorium na podstawie przekazanego ID
            var image = await _imageRepository.Get(request.ImageId);
            if (image == null)
            {
                throw new Exception("Image not found");
            }

            // Pobierz wszystkie obrazy dla produktu
            var imagesForProduct = await _imageRepository.GetImagesByProductId(image.ProductId);

            // Zmodyfikuj flagi IsPrimary dla obrazków
            foreach (var img in imagesForProduct)
            {
                img.IsPrimary = (img.Id == request.ImageId); // Ustaw na true tylko dla obrazka, który ma być ustawiony jako główny
                await _imageRepository.UpdateImage(img);
            }
#cokolwiek

            return Unit.Value;
        }
    }
}
