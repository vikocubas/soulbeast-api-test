1- Instalar frameworks no NuGet: Microsoft.EntityFrameworkCore, Microsoft.EntityFrameworkCoe.SqlServer, Microsoft.EntityFrameworkCore.Tools, Microsoft.EntityFrameworkCore.Design.

2- Criar pasta Models e criar as classes(tabelas) da API.

3- Criar pasta Data e criar classe DataContext e adicionar o DbContext

4- Criar uma database no SQL Server Management Studio

5- Pesquisar no Visual Studio: SQL Server Object Explorer -> Add SQL Server -> (Entra no SQLSMS em propriedades e copia o nome do servidor e cola no Visual Studio e adiciona o Database Name com o projeto criado e conecta) -> Entra no local que foi criado a database e vai em propriedades -> Em connection string Copie o texto criado -> Entre no appsettings.json e crie: 
"ConnectionStrings": {
	"DefaultConnection" : "Cole aqui o texto copiado"
},

6- No DataContext adicione o contexto do banco de dados e faça o DbSet das tabelas

7- No Program.cs abaixo do swagger adicione: builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

8- No Package Console escreva: Add-Migration InitialCreate
			depois escreva: Update-Database

9- Criar a pasta Controller e criar os controllers da API Ex:
[ApiController]
[Route("api/[controller]")]
    public class SoulbeastController : Controller
    {
        private readonly DataContext _dbContext;

        public SoulbeastController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

10- Criar o Método Get Ex:
	 [HttpGet]
       public IActionResult GetSoulbeasts()
        {
            return Ok(_dbContext.Soulbeasts.ToList());        
        }

11- Criar pasta Dto e criar classes Dto e passas somente os dados que vai ser utilizado nos métodos.

12- Criar o Método Post Ex:
	  [HttpPost]
        public async Task<IActionResult> AddSoulbeast(SoulbeastDto soulbeastCreate)
        {
            var soulbeast = new Soulbeast()
            {
                Name = soulbeastCreate.Name,
                Level = soulbeastCreate.Level,
                Element = soulbeastCreate.Element,
                OwnerId = soulbeastCreate.OwnerId,
            };

            await _dbContext.Soulbeasts.AddAsync(soulbeast);
            await _dbContext.SaveChangesAsync();
            return Ok(soulbeast);
            
        }

13- Criar o Método Put/Update Ex:
	  [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateSoulbeast([FromRoute] Guid id, SoulbeastDto soulbeastUpdate)
        {
            var soulbeast = await _dbContext.Soulbeasts.FindAsync(id);

            if (soulbeast != null)
            {
                soulbeast.Name = soulbeastUpdate.Name;
                soulbeast.Level = soulbeastUpdate.Level;
                soulbeast.Element = soulbeastUpdate.Element;
                soulbeast.OwnerId = soulbeastUpdate.OwnerId;

                await _dbContext.SaveChangesAsync();

                return Ok(soulbeast);
            }

            return NotFound();
        }

14- Criar o Método Get por Id Ex:

	  [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetSoulbeast([FromRoute] Guid id)
        {
            var soulbeast = await _dbContext.Soulbeasts.FindAsync(id);

            if(soulbeast == null)
            {
                return NotFound();
            }

            return Ok(soulbeast);
        }

15- Criar o Método Delete por Id Ex:

	  [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteSoulbeast([FromRoute] Guid id)
        {
            var soulbeast = await _dbContext.Soulbeasts.FindAsync(id);

            if (soulbeast != null)
            {
                _dbContext.Remove(soulbeast);
                await _dbContext.SaveChangesAsync();

                return Ok(soulbeast);
            }

            return NotFound();
        }

16- Aproveite o seu CRUD com SQLServer :)











  