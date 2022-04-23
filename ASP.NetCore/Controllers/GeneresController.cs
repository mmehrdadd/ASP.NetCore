using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NetCore.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ASP.NetCore.DTOs;

namespace ASP.NetCore.Controllers
{
    [ApiController]
    [Route("api/genres")]
    public class GeneresController : ControllerBase
    {
        private readonly ILogger<GeneresController> logger;
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public GeneresController(ILogger<GeneresController> logger,AppDbContext context,IMapper mapper)
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<GenresDTOs>>> Get()
        {
            var genres =  await context.Genres.AsNoTracking().ToListAsync();
            var genresDTO = mapper.Map<List<GenresDTOs>>(genres);
            return genresDTO;
        }

        [HttpGet("{id:int}", Name ="getgenre")]
        public async Task<ActionResult<GenresDTOs>> Get(int id)
        {
            var genre = await context.Genres.FirstOrDefaultAsync(x => x.id == id);
            if (genre == null)
                return NotFound();
            var genreDTO = mapper.Map<GenresDTOs>(genre);
                    
            return genreDTO;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GenreCreationDTO genreCreation)
        {
            var genre = mapper.Map<Generes>(genreCreation);
            context.Add(genre);
            await context.SaveChangesAsync();
            var genreDTO = mapper.Map<GenresDTOs>(genre);
            return new CreatedAtRouteResult("getgenre", new { id = genre.id }, genre);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] GenreCreationDTO genreCreation)
        {
            var genre = mapper.Map<Generes>(genreCreation);
            genre.id = id;
            context.Entry(genre).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
   
}
