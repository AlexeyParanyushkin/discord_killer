using Microsoft.AspNetCore.Mvc;

namespace DiscordKiller.Examples.AspNetCore.WebAPI.Controllers;

[ApiController]
[Route("/api/goods")]
public class GoodsController : ControllerBase
{
    private readonly ApplicationDBContext _dbContext;
    
    public GoodsController(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    
    [HttpGet]
    public List<Good> GetList()
    {
        var goods = _dbContext.Goods.ToList();
        return goods;
    }

    [HttpGet("{goodId:int}")]
    public ActionResult<Good> GetById(int goodId)
    {
        var good = _dbContext.Goods.FirstOrDefault(x => x.Id == goodId);
        if (good == null)
            return NotFound();

        return good;
    }

    [HttpPost]
    public ActionResult Add(CreateGood createGood)
    {
        if (createGood.Stock < 0) return BadRequest("Кол-во не может быть < 0");
        if (createGood.Price <= 0) return BadRequest("Цена не может быть <= 0");
        
        var good = new Good()
        {
            Name = createGood.Name,
            Description = createGood.Description,
            Price = createGood.Price,
            Stock = createGood.Stock
        };
        _dbContext.Goods.Add(good);
        _dbContext.SaveChanges();

        return Created($"/api/goods/{good.Id}", good);
    }

    [HttpDelete("{goodId:int}")]
    public ActionResult Delete(int goodId)
    {
        var good = _dbContext.Goods.FirstOrDefault(x => x.Id == goodId);
        if (good == null)
            return NotFound();

        _dbContext.Goods.Remove(good);
        _dbContext.SaveChanges();
        
        return Ok();
    }

    [HttpPost("{goodId:int}")]
    public ActionResult Update(int goodId, CreateGood updateGood)
    {
        var good = _dbContext.Goods.FirstOrDefault(x => x.Id == goodId);
        if (good == null)
            return NotFound();

        if (updateGood.Stock < 0) return BadRequest("Кол-во не может быть < 0");
        if (updateGood.Price <= 0) return BadRequest("Цена не может быть <= 0");
        
        good.Description = updateGood.Description;
        good.Name = updateGood.Name;
        good.Price = updateGood.Price;
        good.Stock = updateGood.Stock;

        _dbContext.SaveChanges();
        
        return Ok();
    }

    [HttpPut]
    public ActionResult UpdateOrCreate(UpdateOrCreateGood updateOrCreateGood)
    {
        if (updateOrCreateGood.Stock < 0) return BadRequest("Кол-во не может быть < 0");
        if (updateOrCreateGood.Price <= 0) return BadRequest("Цена не может быть <= 0");
        
        if (updateOrCreateGood.Id == null)
        {
            var good = new Good()
            {
                Name = updateOrCreateGood.Name,
                Description = updateOrCreateGood.Description,
                Price = updateOrCreateGood.Price,
                Stock = updateOrCreateGood.Stock
            };
            _dbContext.Goods.Add(good);
            _dbContext.SaveChanges();
            
            return Created($"/api/goods/{good.Id}", good);
        }

        var exitsGood = _dbContext.Goods.FirstOrDefault(x => x.Id == updateOrCreateGood.Id);
        if (exitsGood == null)
            return NotFound();

        exitsGood.Description = updateOrCreateGood.Description;
        exitsGood.Name = updateOrCreateGood.Name;
        exitsGood.Price = updateOrCreateGood.Price;
        exitsGood.Stock = updateOrCreateGood.Stock;
        
        _dbContext.SaveChanges();

        return Ok();
    }
}