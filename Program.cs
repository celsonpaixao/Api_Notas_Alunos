using Api_Notas_Aluno.DAL.Database;
using Api_Notas_Aluno.DAL.IRepository;
using Api_Notas_Aluno.DAL.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<INotaRepository, NotaRepository>();
builder.Services.AddTransient<NotaAlunoDbContext>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//construir um aplicativo pelo construtor
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //Adiciona o middleware Swagger para servir a documentação gerada automaticamente
    app.UseSwagger();
    //Adiciona o middleware Swagger UI para visualizar e interagir com a documentação Swagger.
    app.UseSwaggerUI();
}
 //Adiciona middleware para redirecionar requisições HTTP para HTTPS.
app.UseHttpsRedirection();
//Adiciona o middleware de autorização
app.UseAuthorization();
//Adiciona o middleware para rotear solicitações HTTP para os controladores MVC.
app.MapControllers();
// Inicia o processamento de solicitações HTTP
app.Run();
