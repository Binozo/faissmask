using System;
using System.IO;
using Xunit;

namespace FaissMask.Test;

public class IndexPersistencyTests
{
    private const string _indexPath = "data/faiss.index";
    private const string _regeneratedIndexPath = "data/faiss_regenerated.index";
    
    [Fact]
    public void EnsureRegeneratedIndexIsTheSame()
    {
        using var index = IndexFlat.Read(_indexPath);
        index.WriteIndex(_regeneratedIndexPath);
        Assert.True(File.Exists(_regeneratedIndexPath));
        
        byte[] originalIndexBytes = File.ReadAllBytes(_regeneratedIndexPath);
        byte[] regenratedIndexBytes = File.ReadAllBytes(_regeneratedIndexPath);
        Assert.Equal(originalIndexBytes, regenratedIndexBytes);
        
        File.Delete(_regeneratedIndexPath);
    }

}