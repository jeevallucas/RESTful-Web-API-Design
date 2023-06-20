using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using UAS_DRWA_2023.Models;
using UAS_DRWA_2023.Services;
using Microsoft.AspNetCore.Authorization;

// Kelas Controller
[Route("api/[controller]")]
[ApiController]
public class KelasController : ControllerBase
{
    private readonly IMongoCollection<Kelas> _kelasCollection;

    public KelasController(IMongoDatabase database)
    {
        _kelasCollection = database.GetCollection<Kelas>("Kelas");
    }

    // GET: api/Kelas
    [HttpGet]
    public async Task<IEnumerable<Kelas>> Get()
    {
        return await _kelasCollection.Find(k => true).ToListAsync();
    }

    // GET: api/Kelas/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Kelas>> Get(string id)
    {
        var kelas = await _kelasCollection.Find(k => k.Id == new ObjectId(id)).FirstOrDefaultAsync();

        if (kelas == null)
        {
            return NotFound();
        }

        return kelas;
    }

    // POST: api/Kelas
    [HttpPost]
    public async Task<ActionResult<Kelas>> Post(Kelas kelas)
    {
        await _kelasCollection.InsertOneAsync(kelas);
        return CreatedAtAction(nameof(Get), new { id = kelas.Id }, kelas);
    }

    // PUT: api/Kelas/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(string id, Kelas kelas)
    {
        var kelasFromDb = await _kelasCollection.FindOneAndReplaceAsync(k => k.Id == new ObjectId(id), kelas);

        if (kelasFromDb == null)
        {
            return NotFound();
        }

        return NoContent();
    }

    // DELETE: api/Kelas/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _kelasCollection.DeleteOneAsync(k => k.Id == new ObjectId(id));

        if (result.DeletedCount == 0)
        {
            return NotFound();
        }

        return NoContent();
    }
}

// Mapel Controller
[Route("api/[controller]")]
[ApiController]
public class MapelController : ControllerBase
{
    private readonly IMongoCollection<Mapel> _mapelCollection;

    public MapelController(IMongoDatabase database)
    {
        _mapelCollection = database.GetCollection<Mapel>("Mapel");
    }

    // GET: api/Mapel
    [HttpGet]
    public async Task<IEnumerable<Mapel>> Get()
    {
        return await _mapelCollection.Find(m => true).ToListAsync();
    }

    // GET: api/Mapel/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Mapel>> Get(string id)
    {
        var mapel = await _mapelCollection.Find(m => m.Id == new ObjectId(id)).FirstOrDefaultAsync();

        if (mapel == null)
        {
            return NotFound();
        }

        return mapel;
    }

    // POST: api/Mapel
    [HttpPost]
    public async Task<ActionResult<Mapel>> Post(Mapel mapel)
    {
        await _mapelCollection.InsertOneAsync(mapel);
        return CreatedAtAction(nameof(Get), new { id = mapel.Id }, mapel);
    }

    // PUT: api/Mapel/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(string id, Mapel mapel)
    {
        var mapelFromDb = await _mapelCollection.FindOneAndReplaceAsync(m => m.Id == new ObjectId(id), mapel);

        if (mapelFromDb == null)
        {
            return NotFound();
        }

        return NoContent();
    }

    // DELETE: api/Mapel/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _mapelCollection.DeleteOneAsync(m => m.Id == new ObjectId(id));

        if (result.DeletedCount == 0)
        {
            return NotFound();
        }

        return NoContent();
    }
}

// Guru Controller
[Route("api/[controller]")]
[ApiController]
public class GuruController : ControllerBase
{
    private readonly IMongoCollection<Guru> _guruCollection;

    public GuruController(IMongoDatabase database)
    {
        _guruCollection = database.GetCollection<Guru>("Guru");
    }

    // GET: api/Guru
    [HttpGet]
    public async Task<IEnumerable<Guru>> Get()
    {
        return await _guruCollection.Find(g => true).ToListAsync();
    }

    // GET: api/Guru/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Guru>> Get(string id)
    {
        var guru = await _guruCollection.Find(g => g.Id == new ObjectId(id)).FirstOrDefaultAsync();

        if (guru == null)
        {
            return NotFound();
        }

        return guru;
    }

    // POST: api/Guru
    [HttpPost]
    public async Task<ActionResult<Guru>> Post(Guru guru)
    {
        await _guruCollection.InsertOneAsync(guru);
        return CreatedAtAction(nameof(Get), new { id = guru.Id }, guru);
    }

    // PUT: api/Guru/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(string id, Guru guru)
    {
        var guruFromDb = await _guruCollection.FindOneAndReplaceAsync(g => g.Id == new ObjectId(id), guru);

        if (guruFromDb == null)
        {
            return NotFound();
        }

        return NoContent();
    }

    // DELETE: api/Guru/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _guruCollection.DeleteOneAsync(g => g.Id == new ObjectId(id));

        if (result.DeletedCount == 0)
        {
            return NotFound();
        }

        return NoContent();
    }
}

// PresensiHarianGuru Controller
[Route("api/[controller]")]
[ApiController]
public class PresensiHarianGuruController : ControllerBase
{
    private readonly IMongoCollection<PresensiHarianGuru> _presensiHarianGuruCollection;

    public PresensiHarianGuruController(IMongoDatabase database)
    {
        _presensiHarianGuruCollection = database.GetCollection<PresensiHarianGuru>("PresensiHarianGuru");
    }

    // GET: api/PresensiHarianGuru
    [HttpGet]
    public async Task<IEnumerable<PresensiHarianGuru>> Get()
    {
        return await _presensiHarianGuruCollection.Find(p => true).ToListAsync();
    }

    // GET: api/PresensiHarianGuru/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<PresensiHarianGuru>> Get(string id)
    {
        var presensiHarianGuru = await _presensiHarianGuruCollection.Find(p => p.Id == new ObjectId(id)).FirstOrDefaultAsync();

        if (presensiHarianGuru == null)
        {
            return NotFound();
        }

        return presensiHarianGuru;
    }

    // POST: api/PresensiHarianGuru
    [HttpPost]
    public async Task<ActionResult<PresensiHarianGuru>> Post(PresensiHarianGuru presensiHarianGuru)
    {
        await _presensiHarianGuruCollection.InsertOneAsync(presensiHarianGuru);
        return CreatedAtAction(nameof(Get), new { id = presensiHarianGuru.Id }, presensiHarianGuru);
    }

    // PUT: api/PresensiHarianGuru/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(string id, PresensiHarianGuru presensiHarianGuru)
    {
        var presensiHarianGuruFromDb = await _presensiHarianGuruCollection.FindOneAndReplaceAsync(p => p.Id == new ObjectId(id), presensiHarianGuru);

        if (presensiHarianGuruFromDb == null)
        {
            return NotFound();
        }

        return NoContent();
    }

    // DELETE: api/PresensiHarianGuru/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _presensiHarianGuruCollection.DeleteOneAsync(p => p.Id == new ObjectId(id));

        if (result.DeletedCount == 0)
        {
            return NotFound();
        }

        return NoContent();
    }
}

// PresensiMengajar Controller
[Route("api/[controller]")]
[ApiController]
public class PresensiMengajarController : ControllerBase
{
    private readonly IMongoCollection<PresensiMengajar> _presensiMengajarCollection;

    public PresensiMengajarController(IMongoDatabase database)
    {
        _presensiMengajarCollection = database.GetCollection<PresensiMengajar>("PresensiMengajar");
    }

    // GET: api/PresensiMengajar
    [HttpGet]
    public async Task<IEnumerable<PresensiMengajar>> Get()
    {
        return await _presensiMengajarCollection.Find(p => true).ToListAsync();
    }

    // GET: api/PresensiMengajar/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<PresensiMengajar>> Get(string id)
    {
        var presensiMengajar = await _presensiMengajarCollection.Find(p => p.Id == new ObjectId(id)).FirstOrDefaultAsync();

        if (presensiMengajar == null)
        {
            return NotFound();
        }

        return presensiMengajar;
    }

    // POST: api/PresensiMengajar
    [HttpPost]
    public async Task<ActionResult<PresensiMengajar>> Post(PresensiMengajar presensiMengajar)
    {
        await _presensiMengajarCollection.InsertOneAsync(presensiMengajar);
        return CreatedAtAction(nameof(Get), new { id = presensiMengajar.Id }, presensiMengajar);
    }

    // PUT: api/PresensiMengajar/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(string id, PresensiMengajar presensiMengajar)
    {
        var presensiMengajarFromDb = await _presensiMengajarCollection.FindOneAndReplaceAsync(p => p.Id == new ObjectId(id), presensiMengajar);

        if (presensiMengajarFromDb == null)
        {
            return NotFound();
        }

        return NoContent();
    }

    // DELETE: api/PresensiMengajar/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _presensiMengajarCollection.DeleteOneAsync(p => p.Id == new ObjectId(id));

        if (result.DeletedCount == 0)
        {
            return NotFound();
        }

        return NoContent();
    }
}